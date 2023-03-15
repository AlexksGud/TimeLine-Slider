using System.Collections;
using UnityEngine;

public class FocusPoint : ContentInTimeLine
{
    [SerializeField] private HorizontalTimeline _timeline;
    [SerializeField] private float _scrollSpeed;
    private void Awake()
    {
        Init();
    }
    bool showing = false;
    void Update()
    {
        if (_timeline.IsDraging|| showing)
            return;

        if (IsFar())
            return;

        if (InShowRange())
            Show();
       

    }
    protected override void Show()
    {
        _timeline.scrollVelocity = 0;
        _timeline.SlideCorutinine = this;
        StartCoroutine(SlideToPoint());
    }
    IEnumerator SlideToPoint()
    {

        showing = true;

        float dir;
        if (transform.position.x > 0) 
            dir = 1;
        else 
            dir = -1;

        while (Mathf.Abs(transform.position.x)>2f)
        {
            var newpos =  _timeline.TimelineRect.anchoredPosition.x //curent
                        - _scrollSpeed * Time.deltaTime * dir;      //added

            var newX = Mathf.Clamp(newpos, -_timeline.TimelineRect.sizeDelta.x, 0);

            _timeline.TimelineRect.anchoredPosition = new Vector2(newX, 0f);

            
            yield return null;
        }
    }
    public void StopSlide()
    {
        showing = false;
        StopAllCoroutines();
    }

}
