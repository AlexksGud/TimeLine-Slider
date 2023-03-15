using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_ITL : ContentInTimeLine
{
    [SerializeField] private Transform _scaleTarget;
    private void Awake()
    {
        Init();
    }
    private void Start()
    {
        _scaleTarget.localScale= Vector3.zero;
    }

    private void Update()
    {

        _sliderValue = _slider.Value;
        if (InShowRange())
            Show();

        if(InHideRange())
            Hide();
    }
    protected override void Show()
    {
        float _progressValue;
        _progressValue = Mathf.InverseLerp(minShowSector, maxShowSector, _sliderValue);
        _scaleTarget.localScale = new Vector3(_progressValue, _progressValue);
    }

    protected override void Hide()
    {
        float _progressValue;
        _progressValue = 1 - Mathf.InverseLerp(minHideSector, maxHideSector, _sliderValue);
      
        _scaleTarget.localScale = new Vector3(_progressValue, _progressValue);
    }
}
