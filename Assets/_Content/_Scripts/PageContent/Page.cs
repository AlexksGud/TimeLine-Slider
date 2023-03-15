using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Page : MonoBehaviour
{
    protected MainSlider _slider;

    public virtual void Init()
    {
        _slider = GameObject.FindGameObjectWithTag("MainSlider")
                                      .GetComponent<MainSlider>();

    }
    public abstract void Show();
    public abstract void Hide();

}
