using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ContentAndPage_ITL : Animation_ITL, IFocusPoint
{
    [SerializeField] private Page _page;
    [SerializeField] private Button _butt;
    [SerializeField] private Button _closeButt;
    [SerializeField] private float _scrollSpeed;

    private HorizontalTimeline _timeline;
    private void Start()
    {
        _timeline = GameObject.FindGameObjectWithTag("Player")
                          .GetComponent<HorizontalTimeline>();

          _butt.onClick.AddListener(ShowPage);
          _closeButt?.onClick.AddListener(HidePage);
    }
  
    private void ShowPage()
    {
        _page.Show();
        _closeButt.gameObject.SetActive(true);
        _timeline.scrollVelocity = 0;
        _timeline.SlideCorutinine = this;

        StartCoroutine(SlideToPoint());
    }
    private void HidePage()
    {
        _closeButt.gameObject.SetActive(false);
        _page.Hide();
    }
    IEnumerator SlideToPoint()
    {


        float dir;
        if (transform.position.x > 0)
            dir = 1;
        else
            dir = -1;

        while (Mathf.Abs(transform.position.x) > 2f)
        {
            var newpos = _timeline.TimelineRect.anchoredPosition.x //curent
                        - _scrollSpeed * Time.deltaTime * dir;      //added

            var newX = Mathf.Clamp(newpos, -_timeline.TimelineRect.sizeDelta.x, 0);

            _timeline.TimelineRect.anchoredPosition = new Vector2(newX, 0f);


            yield return null;
        }
    }
    public void StopFocus()
    {
        StopAllCoroutines();
    }
}

public interface IFocusPoint
{
    void StopFocus();
}

