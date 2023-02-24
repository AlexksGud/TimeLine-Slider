using UnityEngine;

public class PointFocus : ContentInTimeLine
{
    [SerializeField] private float value;


    private void Awake()
    {
        _slider = GameObject.FindGameObjectWithTag("MainSlider")
                                   .GetComponent<MainSlider>();
        _helper.CollectContent(this);

        minShowSector = _slider.RecalculateValues(contentLength, minShowSector);        
        maxShowSector = _slider.RecalculateValues(contentLength, maxShowSector);
        value = (minShowSector + maxShowSector) / 2;
    }
    private bool _sliding;
    private void Update()
    {
        if (Mathf.Approximately(_slider.Value, value) || _sliding == true) 
            return;


        _sliderValue = _slider.Value;

        if (InMinRange())
        {
            _slider.SlideToPoint(minShowSector,maxShowSector);
            _sliding = true;
        }
        
    }
   
    private void OnDisable()
    {
        _sliding = false;
    }
   
}

