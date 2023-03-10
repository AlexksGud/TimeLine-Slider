using System.Collections;
using UnityEngine;


public class ScaleOutTimeLine : ContentAboveTimeLine
{

    [SerializeField] private Transform _scaleTarget;


    private void Awake()
    {
        Init();

    }

    private void Update()
    {
         _sliderValue = _slider.Value;

        if (InShowRange()) 
            Show();       

        if (InHideRange())
            Hide();          
               
    }
    protected override void Show()
    {
        var 
        _progressValue = Mathf.InverseLerp(minShowSector, maxShowSector, _sliderValue);
        _scaleTarget.localScale = new Vector3(_progressValue, _progressValue);
    }

    protected override void Hide()
    {
        var
        _progressValue = 1 - Mathf.InverseLerp(minHideSector, maxHideSector, _sliderValue);
        _scaleTarget.localScale = new Vector3(_progressValue, _progressValue);
    }


}
