using System.Collections;
using UnityEngine;

public class FocusPoint : ContentInTimeLine,IFocusPoint
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
        _timeline.SlideCorutinine = this; //кэш куратины ( чтобы выключить еЄ если юзер не долждетс€ конца прит€жени€ и начнет листать дальше)
        StartCoroutine(SlideToPoint());
    }
    IEnumerator SlideToPoint()
    {

        showing = true;

        //провер€ем в какую сторону прит€гивать
        float dir;
        if (transform.position.x > 0) 
            dir = 1;
        else 
            dir = -1;

        while (Mathf.Abs(transform.position.x)>2f)
        {
            var newpos =  _timeline.TimelineRect.anchoredPosition.x //curent
                        - _scrollSpeed * Time.deltaTime * dir;      //added

            var newX = Mathf.Clamp(newpos, -_timeline.TimelineRect.sizeDelta.x, 0); // на вс€кий случай 

            _timeline.TimelineRect.anchoredPosition = new Vector2(newX, 0f);

            
            yield return null;
        }
    }

    public void StopFocus()
    {
        showing = false;
        StopAllCoroutines();
    }
}
