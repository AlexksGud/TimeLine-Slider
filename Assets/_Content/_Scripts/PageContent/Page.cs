using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Page : MonoBehaviour
{
    protected MainSlider _slider;

    private Vector3 _basepos;
    public virtual void Init()
    {
        _basepos = transform.position;
        _slider = GameObject.FindGameObjectWithTag("MainSlider")
                                      .GetComponent<MainSlider>();

    }
    public abstract void Show();
    public abstract void Hide();

    protected void ReturnToStartPoint()
    {
        transform.position = _basepos;
    }
    protected void MoveToCameraView()
    {
        transform.localPosition = Vector2.zero;
    }

}
