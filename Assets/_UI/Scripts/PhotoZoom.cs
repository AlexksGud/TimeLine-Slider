
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PhotoZoom : MonoBehaviour
{
    private PhotoPage _photoPage;
    private Button _button;

    [SerializeField] private Image _photo;
    [SerializeField] private float _zoomMultiplier = 1.5f;

    private void Awake()
    {
        _photoPage = GameObject.FindGameObjectWithTag("PhotoPage")
                                 .GetComponent<PhotoPage>();

        _button=GetComponent<Button>();
        _button.onClick.AddListener(OnPhotoClick);

    }

    public void OnPhotoClick()
    {
        
        _photoPage.GetPhoto(_photo.transform.position, _zoomMultiplier, _photo);
       
    }
}

