using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class HorizontalTimeline : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public float scrollSpeed = 10f;                // The _followSpeed at which the timeline scrolls
    public float inertiaDecelerationRate = 0.975f; // The rate at which the scrolling _followSpeed decelerates after a touch ends

    public float scrollVelocity = 0f;


    public float maxScrollVelocity;
    public float targetThreshold = 5f;
    public float inertiaMulti;

    public float minRange;

    private RectTransform timelineTransform;
    public RectTransform TimelineRect => timelineTransform;

    private IFocusPoint _slideFocus;
    public IFocusPoint SlideCorutinine
    {
        set
        {
            if (_slideFocus != null)
                _slideFocus.StopFocus();

            _slideFocus = value;
        }
    }

    private void Awake()
    {
        timelineTransform = GetComponent<RectTransform>();
    }

    private Vector2 targetPosition;
    public bool _dragEnd;
    public float AFKinSecons;
    private bool _timerStarted;
    private void Start()
    {
        StartCoroutine(NoTouchTimer());
    }
    private void Update()
    {
        //—юда лезть не нужно 
        if (_dragEnd)
        {
            // Calculate the distance from the target position
            float distance = Vector2.Distance(timelineTransform.anchoredPosition, targetPosition);

            if (distance > targetThreshold)
            {
                // Calculate the scroll delta based on the current velocity
                float scrollDelta = Time.deltaTime * scrollVelocity;
                var x = Mathf.Clamp(timelineTransform.anchoredPosition.x - scrollDelta, -TimelineRect.sizeDelta.x, minRange);
                // Move the timeline based on the scroll delta
                timelineTransform.anchoredPosition = new Vector2(x, 0f);

                // Decelerate the scrolling velocity over time
                scrollVelocity *= inertiaDecelerationRate;

                // Clamp the scrolling velocity to the maximum velocity
                scrollVelocity = Mathf.Clamp(scrollVelocity, -maxScrollVelocity, maxScrollVelocity);
            }
            else
            {
                // Stop scrolling when the timeline reaches the target position
                _dragEnd = false;
                scrollVelocity = 0f;
            }
        }

        if (Input.touchCount == 0 && !_timerStarted)
        {
            StartCoroutine(NoTouchTimer());
        }
    }
    
    public bool IsDraging { get; private set; }


    public void OnBeginDrag(PointerEventData eventData)
    {
        // Stop scrolling when the user begins dragging the timeline
        _dragEnd = false;
        StopCoroutine(nameof(NoTouchTimer));
        _timerStarted = false;
        IsDraging = true;


        if (_slideFocus != null)
        {
            _slideFocus.StopFocus();
            SlideCorutinine = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

        // Move the timeline based on the touch delta
        var delta = eventData.delta.x * scrollSpeed;
        var x = Mathf.Clamp(timelineTransform.anchoredPosition.x + delta, -TimelineRect.sizeDelta.x, minRange);

        timelineTransform.anchoredPosition = new Vector2(x, 0f);

        float touchTime = Time.time - eventData.clickTime;
        scrollVelocity = (eventData.delta.x / touchTime) * inertiaMulti;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        targetPosition = timelineTransform.anchoredPosition + new Vector2(scrollVelocity, 0f) * 10f;
        _dragEnd = true;
        IsDraging = false;


    }

    public float afkscrollspeed = 200f;
    private IEnumerator NoTouchTimer()
    {
        _timerStarted = true;
        float timetotal = 0;

        while (timetotal < AFKinSecons)
        {
            timetotal += Time.deltaTime;
            yield return null;
        }


        var lenght = timelineTransform.anchoredPosition.x + 2;
        while (lenght <= TimelineRect.sizeDelta.x)
        {

            var x = Mathf.Clamp(timelineTransform.anchoredPosition.x - afkscrollspeed * Time.deltaTime, -TimelineRect.sizeDelta.x, minRange);

            timelineTransform.anchoredPosition = new Vector2(x, 0f);


            yield return null;
        }
        _timerStarted = false;



    }

    public void EnableTimeline(bool value)
    {
        this.enabled = value;
    }


}
