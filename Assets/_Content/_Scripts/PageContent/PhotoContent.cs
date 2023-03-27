
using Coffee.UIExtensions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PhotoContent : PageWithAnimator
{
    [SerializeField] private Button  _leftButton,_rightButton;
    [SerializeField] private List<UITransitionEffect> _photos;


    private int currentPhoto = 0;
    private int photoCount;
    private void Start()
    {
        _leftButton.onClick.AddListener(Next);
        _rightButton.onClick.AddListener(Previous);
        photoCount = _photos.Count - 1;
    }


    public override void Show()
    {
        base.Show();
        if (currentPhoto == 0)
            return;

        _photos[currentPhoto].effectFactor=0;
        _photos[currentPhoto = 0].Show();

    }

    private void Next()
    {
        _photos[currentPhoto].Hide();

        if (currentPhoto == photoCount)
            ShowPhoto(0);
        else
            ShowPhoto(++currentPhoto);

    }

    private void Previous()
    {
        _photos[currentPhoto].Hide();

        if (currentPhoto == 0)
            ShowPhoto(photoCount);
        else
            ShowPhoto(--currentPhoto);
    }

    private void ShowPhoto(int indx)
    {
        _photos[indx].transform.SetAsLastSibling();
        _photos[indx].Show();
        currentPhoto = indx;
    }
 

}
