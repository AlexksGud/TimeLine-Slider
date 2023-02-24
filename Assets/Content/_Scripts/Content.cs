using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Content : MonoBehaviour
{
    [Header("Sector of appereance")]
    [SerializeField, ContentLength]
    protected float minShowSector, maxShowSector;
    [SerializeField, Tooltip("Value when hiding starts"), ContentLength]
    protected float minHideSector; 
    [SerializeField, Tooltip("Value when hiding ends"), ContentLength]
    protected float maxHideSector;

    protected MainSlider _slider;
    protected float _sliderValue;

    /// <summary>
    /// «начение прогресса анимации/увеличени€/про€влени€
    /// </summary>
    protected float _progressValue;
    protected float _minProgressV, _maxProgressV;

    public float contentLength;

    [SerializeField] protected SubSliderHelper _helper;
    /// <summary>
    /// Call in awake
    /// </summary>
    protected abstract void Init();
    protected abstract void Show();
    protected abstract void Hide();
    public abstract void Enable();
    public abstract void Disable();

    protected bool InMinRange(float sliderValue)
    {
        return sliderValue >= minShowSector && sliderValue < maxShowSector;
    }
    protected bool InMaxRange(float sliderValue)
    {
        return sliderValue >= minHideSector;
    }
    protected bool InMinRange()
    {
        return _sliderValue >= minShowSector && _sliderValue < maxShowSector;
    }
    protected bool InMaxRange()
    {
        return _sliderValue >= minHideSector;
    }


}
public class ContentInTimeLine : Content
{

    public override void Disable()
    {
        StartCoroutine(Disabling());
    }

    public override void Enable()
    {
        this.enabled = true;
    }

    protected override void Init()
    {
        _slider = GameObject.FindGameObjectWithTag("MainSlider")
                                 .GetComponent<MainSlider>();
        _helper.CollectContent(this);
    }

    protected override void Show()
    {
        throw new System.NotImplementedException();
    }
    protected override void Hide()
    {
        throw new System.NotImplementedException();
    }
    protected IEnumerator Disabling()
    {
        while (_progressValue > _minProgressV)
        {
            yield return null;
        }


        this.enabled = false;
    }
}
public class ContentAboveTimeLine : Content
{
    private Vector3 _startPos;
    [SerializeField] protected CanvasGroup _parent;

    public override void Disable()
    {
        StartCoroutine(Disabling());
    }

    public override void Enable()
    {
        _parent.transform.position = Vector3.zero;
        this.enabled = true;
    }

    protected override void Init()
    {
        _slider = GameObject.FindGameObjectWithTag("MainSlider")
                                .GetComponent<MainSlider>();
        _helper.CollectContent(this);

        _startPos = _parent.transform.position;
    }

    protected override void Show()
    {
        throw new System.NotImplementedException();
    }
    protected override void Hide()
    {
        throw new System.NotImplementedException();
    }
    protected IEnumerator Disabling()
    {
        while (_progressValue > _minProgressV)
        {
            yield return null;
        }

        _parent.transform.position = _startPos;
        this.enabled = false;
    }
}
