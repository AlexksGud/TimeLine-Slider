using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SubSliderHelper : MonoBehaviour
{
    [SerializeField] private float min, max;
    [SerializeField] private SubSliderHelper _leftHelper, _rightHelper;

    private MainSlider _mainSlider;

    private void Awake()
    {
        _mainSlider = GameObject.FindGameObjectWithTag("MainSlider")
                                .GetComponent<MainSlider>();

        if (_leftHelper == null)
        {
            InitHelpers();
        }
    }
    private void InitHelpers()
    {
        _rightHelper.TurnOff();
    }

    float lastFrameV = 0;
    private void Update()
    {
        var v = _mainSlider.Value;

        if (NoValueChanged()) 
            return;

       
        if (v <= min)
        {
            _leftHelper?.TurnOn();
            _rightHelper?.TurnOff();
        }

        if (v >= max)
        {
            _leftHelper?.TurnOff();
            _rightHelper?.TurnOn();
        }

        lastFrameV = v;


        bool NoValueChanged() 
        {
            if(v == lastFrameV) 
                return true;

            return false; 
        }

    }

    private List<Content> _conntent = new List<Content>();
    public void CollectContent(Content content)
    {
        _conntent.Add(content);
    }

    bool _enabled = false;
    public void TurnOff()
    {
        if (!_enabled) 
            return;

        _enabled = false;
        enabled = _enabled;

        foreach (var item in _conntent)
        {
            item.Disable();
        }
    }
    public void TurnOn()
    {
        if (_enabled) 
            return;

        _enabled = true;
        enabled = _enabled;

        foreach (var item in _conntent)
        {
            item.Disable();
        }
    }
}



