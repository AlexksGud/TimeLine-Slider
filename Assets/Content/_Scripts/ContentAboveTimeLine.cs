using System.Collections;
using UnityEngine;

public class ContentAboveTimeLine : Content
{
    private Vector3 _startPos;
    [SerializeField] protected CanvasGroup _parent;

 

    protected override void Init()
    {
        _slider = GameObject.FindGameObjectWithTag("MainSlider")
                                .GetComponent<MainSlider>();

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
      
        yield return null;
        

        _parent.transform.position = _startPos;
        this.enabled = false;
    }
}
