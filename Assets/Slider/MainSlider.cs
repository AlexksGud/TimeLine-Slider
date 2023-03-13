using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainSlider : MonoBehaviour
{
    public float Value => _remapedValue;

    [SerializeField] private HorizontalTimeline _scrollRect;
    [SerializeField] private float maxRemapedValue = 1000;



    private float newContentLength;

    private void Start()
    {
        newContentLength = _scrollRect.TimelineRect.sizeDelta.x;
        print($"Content lenght:{newContentLength}");
    }
    private float _remapedValue;

    private void Update()
    {

        _remapedValue = Remap(-_scrollRect.TimelineRect.anchoredPosition.x, 0, newContentLength, 0, maxRemapedValue);
       
    }


    private float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }


    public void HideTimeline(SliderHideType type)
    {
        switch (type)
        {
            case SliderHideType.Zoom:
                break;
            case SliderHideType.Scale:
                break;
            default:
                break;
        }
    }

}
public enum SliderHideType
{
    Zoom,
    Scale
}
