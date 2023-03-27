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

    //Фото вылетает с угла ибо при начале вылета координата z = -3000
    //я так и не понял как исправить это 
    public override void Show()
    {
        transform.localPosition = new Vector3(0, 0, transform.localPosition.z);
        _photoPlace.transform.DOLocalMove(Vector3.zero, 1f);
        _photoPlace.rectTransform.DOScale(_zoomV, 1f);
    
    }

    public void GetPhoto(Vector3 startPos, float zoomValue, Image photo)
    {
        _slider.EnableTimeline(false);
        _photoPlace.DOFade(1,0.1f);
        _photoPlace.sprite = photo.sprite;

        //Идея такая что мы "спавним" фото на которое тыкнули поверх этого фото 
        var r = photo.rectTransform.rect;
        _photoPlace.rectTransform.sizeDelta = new Vector2(r.width, r.height);
        _photoPlace.transform.position = new Vector3 (startPos.x,startPos.y, startPos.z);

        _zoomV = zoomValue;
        Show();

    }
}

