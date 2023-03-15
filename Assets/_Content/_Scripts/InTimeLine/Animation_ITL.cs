using UnityEngine;

public class Animation_ITL : ContentInTimeLine 
{
    private Animator _animator;
    private void Awake()
    {
        Init();
        _animator = GetComponent<Animator>();

    }
    public bool showPos=false;
    private void Update()
    {
        if (showPos)
            print(transform.position.x);

        if (IsFar())
            return;
       
        if (InShowRange())
            Show();

        if (InHideRange())
            Hide();
    }
    protected override void Show()
    {
        if (!_animator.GetBool("Show"))          
             _animator.SetBool("Show",true);
    }
    protected override void Hide()
    {
        if (_animator.GetBool("Show"))
            _animator.SetBool("Show",false);
    }
  
}

