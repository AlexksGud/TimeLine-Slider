using System.Collections;
using UnityEngine;

public class ContentInTimeLine : Content
{
 
    protected override void Init()
    {
        _slider = GameObject.FindGameObjectWithTag("Player")
                                 .GetComponent<HorizontalTimeline>();
      
    }

    protected override void Show()
    {
        
    }
    protected override void Hide()
    {
       
    }
 
}
