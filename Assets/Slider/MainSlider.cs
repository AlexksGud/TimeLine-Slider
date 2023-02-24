using DG.Tweening;
using System.Collections;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainSlider : MonoBehaviour
{
    public float Value => _remapedValue;

    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private float maxRemapedValue = 1000;
    
    private Scrollbar _slider;
    private float newContentLength;
    private void Awake()
    {
        _slider = _scrollRect.horizontalScrollbar;
        newContentLength = _scrollRect.content.sizeDelta.x;
    }

    private float _remapedValue;
    
    private void Update()
    {
        _remapedValue = Remap(_slider.value, 0, 1, 0, maxRemapedValue);

    }

    private float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }

    public void SlideToPoint(float min,float max)
    {
        var minv = Mathf.Clamp01(min);
        var maxv = Mathf.Clamp01(max);

        StartCoroutine(SlidingToPoint(minv,maxv));
    }


    [Header("Sliding values")]
    [SerializeField] private float _duration;
    [SerializeField] private AnimationCurve _curve;
    private IEnumerator SlidingToPoint(float min,float max)
    {
        float startTime = Time.time;
        float endTime = startTime + _duration;
        float startValue = _slider.value;
        float targetValue = (min + max) / 2;

        while (!_draging && Time.time < endTime)
        {

           
            float t = (Time.time - startTime) / _duration;
            float curveValue = _curve.Evaluate(t);
            _slider.value = Mathf.Lerp(startValue, targetValue, curveValue);

            if (CompareFloats(_slider.value, min, max)) 
                yield break;

            yield return null;
        }

        bool CompareFloats(float value, float min,float max)
        {
            return Mathf.Approximately(value, min) || Mathf.Approximately(value, max);
        }
    }
    /// <summary>
    /// Пересчитывает значения если длина контента изменилась
    /// </summary>
    /// <param name="contentLength">Длина контента при котором вводилось значение</param>
    /// <param name="valueForChange">Значение для remaped slide.value  [0,1000]</param>
    /// <returns></returns>
    public float RecalculateValues(float contentLength, float valueForChange)
    {
        if (contentLength == newContentLength)
            return valueForChange;

        float sliderValueMultiplier = newContentLength / contentLength; // коэффициент масштабирования значений слайдера

        float oldValue = valueForChange; // старое значение слайдера объекта
        float oldValueNormalized = oldValue / contentLength; // старое значение слайдера в диапазоне [0,1]
        float newValueNormalized = oldValueNormalized * sliderValueMultiplier; // новое значение слайдера в диапазоне [0,1]
        float newValue = newValueNormalized * newContentLength; // новое значение слайдера объекта
        return newValue;


    }

    private bool _draging;
    private void OnMouseDrag()
    {
        StopCoroutine(nameof(SlideToPoint));
        _draging = true;
    }
    private void OnMouseUp()
    {
        _draging = false;
    }
}
