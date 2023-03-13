using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Page : MonoBehaviour
{
    protected MainSlider _slider;
    protected ContentSector _sector;
    public virtual void Init()
    {
        _slider = GameObject.FindGameObjectWithTag("MainSlider")
                                      .GetComponent<MainSlider>();

        _sector = transform.parent.GetComponent<ContentSector>();
    }
    public abstract void Show();
    public abstract void Hide();

}
