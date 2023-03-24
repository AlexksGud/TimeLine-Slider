using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhotoPage : Page
{
    [SerializeField] private Image _photoPlace;

    private float _zoomV;
 

    [SerializeField] private Button _closeBut;
    private void Start()
    {
        Init();
        _closeBut.onClick.AddListener(() =>
        {
            Hide();
        });

    }
    public override void Hide()
    {
        _slider.EnableTimeline(true);
        
        _photoPlace.DOFade(0, 0.5f).OnComplete( ReturnToStartPoint );
    }

    public override void Show()
    {
        MoveToCameraView();
        _photoPlace.transform.DOLocalMove(Vector3.zero, 1f);
        _photoPlace.rectTransform.DOScale(_zoomV, 1f);
    
    }

    public void GetPhoto(Vector3 startPos, float zoomValue, Image photo)
    {
        _slider.EnableTimeline(false);
        _photoPlace.DOFade(1,0.1f);
        _photoPlace.sprite = photo.sprite;

        var r = photo.rectTransform.rect;
        _photoPlace.rectTransform.sizeDelta = new Vector2(r.width, r.height);
        _photoPlace.transform.position = new Vector3 (startPos.x,startPos.y,0);

        _zoomV = zoomValue;
        Show();

    }
}

