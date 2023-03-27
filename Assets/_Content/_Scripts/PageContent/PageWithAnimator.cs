using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageWithAnimator : Page
{
    private Animator animator;
    private event Action OnShow, OnHide;
    [SerializeField] private ScrollRect _scroll;
    [SerializeField] private float _animationDuration=0.84f;
    private void Awake()
    {
        Init();

       if (TryGetComponent<Animator>(out animator))
       {
            //Main subscribe

            OnShow += (() => 
            {
               
                if (!animator.GetBool("Show"))
                {

                    MoveToCameraView();
                    animator.SetBool("Show", true);
                    _slider.EnableTimeline(false);

                    if (_scroll)
                        _scroll.verticalScrollbar.value = 1;
                }
                  

            });

            OnHide += (() => 
            {
                if (animator.GetBool("Show"))
                {
                    animator.SetBool("Show", false);
                    _slider.EnableTimeline(true);

                    Invoke(nameof(ReturnToStartPoint), _animationDuration);

                }
                    
            });


       }
        //Test subscribe (можешь сюда не смотреть даже)
        else
        {
           
            OnShow += (() => 
            {
                transform.position = Vector3.zero;
                this.gameObject.SetActive(true);
            });

            OnHide += (() => 
            {
                this.gameObject.SetActive(false);
            });
       }
       
    }

    public override void Hide()
    {
        OnHide?.Invoke();
    }

    public override void Show()
    {
        OnShow?.Invoke();      
    }

   
}
