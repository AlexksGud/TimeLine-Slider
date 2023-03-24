using System.Collections;
using UnityEngine;

public class Animation_ITL : ContentInTimeLine 
{
    private Animator _animator;
    private void Awake()
    {
        Init();
        _animator = GetComponent<Animator>();

    }

    private void Update()
    {

        if (IsFar())
            return;
       
        if (InShowRange())
            Show();

        if (InHideRange())
            Hide();
    }
    [SerializeField] private float _animationDuration;
    protected override void Show()
    {
        if (!_animator.GetBool("Show") && !_hiding)
            StartCoroutine(ShowingCor());
            
    }
    protected override void Hide()
    {
        if (_animator.GetBool("Show") && !_showing)
            StartCoroutine(HidingCor());

    }

    private bool _showing, _hiding;
    IEnumerator ShowingCor()
    {
        _showing = true;
        _animator.SetBool("Show", true);

        yield return new WaitForSeconds(_animationDuration);
        _showing = false;
    }
    IEnumerator HidingCor()
    {
        _hiding = true;
        _animator.SetBool("Show", false);

        yield return new WaitForSeconds(_animationDuration);
        _hiding = false;
    }
  
}

