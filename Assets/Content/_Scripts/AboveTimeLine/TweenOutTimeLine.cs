using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

public class TweenOutTimeLine : ContentAboveTimeLine
{
    private Sequence _sequence;
    private Sequence _backSequence;

    private void Awake()
    {
        Init();
        _minProgressV = 0;
    }
    private void Start()
    {
        //Example
        //_sequence = DOTween.Sequence();
        //_sequence.Append(transform.DOMoveX(5f, 1f));
        //_sequence.Append(transform.DORotate(new Vector3(0f, 90f, 0f), 1f));
        //_sequence.Append(transform.DOScale(new Vector3(2f, 2f, 2f), 1f));
        //_sequence.SetAutoKill(false);
        
    }
    private void Update()
    {
        _sliderValue = _slider.Value;

        if (InMinRange()) 
            Show();

        if (InMaxRange())
            Hide();
    }
    protected void InitSeq(Sequence s_forward,Sequence s_backward=null)
    {
        _sequence = DOTween.Sequence(s_forward);

        if(s_backward==null)
        {
            _backSequence = DOTween.Sequence(s_forward).SetInverted();
        }
        else
        {
            _backSequence = DOTween.Sequence(s_backward);
        }
      
    }
    protected override void Show()
    {
        _sequence.Play();
        
        
    }
    protected override void Hide()
    {//NEED TEST
        _backSequence.Play().OnComplete(() => _progressValue = 0);
    }


}
public class CardsInRow_ATL : TweenOutTimeLine
{
    public Transform objTop, objBot;
    private void Start()
    {
      // var forwSeq = 
    }
}
