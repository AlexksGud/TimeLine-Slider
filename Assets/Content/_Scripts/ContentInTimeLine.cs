using System.Collections;
using UnityEngine;

public class ContentInTimeLine : Content
{
 
    protected override void Init()
    {
        _slider = GameObject.FindGameObjectWithTag("MainSlider")
                                 .GetComponent<MainSlider>();
      
    }

    protected override void Show()
    {
        
    }
    protected override void Hide()
    {
       
    }
 
}
