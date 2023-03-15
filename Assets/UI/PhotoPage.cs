using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhotoPage : Page
{
    [SerializeField] private Image _photoPlace;

    private float _zoomV;
    private Vector3 _basepos;

    [SerializeField] private Button _closeBut;
    private void Start()
    {
        _basepos = transform.position;

        _closeBut.onClick.AddListener(() =>
        {
            Hide();
        });

        _slider = GameObject.FindGameObjectWithTag("MainSlider")
                         .GetComponent<MainSlider>();
    }
    public override void Hide()
    {
        _slider.EnableTimeline(true);
        
        _photoPlace.DOFade(0, 0.5f).OnComplete(() 
                                  => transform.position = _basepos );
    }

    public override void Show()
    {
       transform.localPosition = Vector3.zero;
      _photoPlace.rectTransform.DOScale(_zoomV, 1f);
      _photoPlace.transform.DOLocalMove(Vector3.zero, 1f);
    }

    public void GetPhoto(Vector3 startPos, float zoomValue, Image photo)
    {
        _slider.EnableTimeline(false);
        _photoPlace.DOFade(1,0.1f);
        _photoPlace.sprite = photo.sprite;

        var r = photo.rectTransform.rect;
        _photoPlace.rectTransform.sizeDelta = new Vector2(r.width, r.height);
        _photoPlace.transform.position = startPos;

        _zoomV = zoomValue;
        Show();

    }
}

