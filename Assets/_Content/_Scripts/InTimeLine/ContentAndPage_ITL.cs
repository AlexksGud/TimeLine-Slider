using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ContentAndPage_ITL : Animation_ITL
{
    [SerializeField] private Page _page;
    [SerializeField] private Button _butt;
    [SerializeField] private Button _closeButt;
    [SerializeField] private float _scrollSpeed;

    [SerializeField] private Image _backGroundMask; 

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

        LayerOrderAndMaskPosition();

        void LayerOrderAndMaskPosition()
        {
            // ставим маску 
            _backGroundMask.raycastTarget = true;
            _backGroundMask.transform.position = new Vector3(0, 0, transform.position.z);
            // порядок в иерархии
            _backGroundMask.transform.SetAsLastSibling();
            transform.SetAsLastSibling();

            _backGroundMask.DOFade(0.6f, 0.6f);
        }
    }
    private void HidePage()
    {
        _closeButt.gameObject.SetActive(false);
        _backGroundMask.DOFade(0f, 0.6f);
        _backGroundMask.raycastTarget = false;
        _page.Hide();
    }
}

public interface IFocusPoint
{
    void StopFocus();
}

