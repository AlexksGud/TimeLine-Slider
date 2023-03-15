using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageWithAnimator : Page
{
    private Animator animator;
    private event Action OnShow, OnHide;
    private void Awake()
    {
        Init();

       if (TryGetComponent<Animator>(out animator))
       {
            OnShow += (() => 
            {
                transform.position = Vector3.zero;
                if (!animator.GetBool("Show"))
                    animator.SetBool("Show", true);
            });

            OnHide += (() => 
            {
                if (animator.GetBool("Show"))
                    animator.SetBool("Show", false);
            });
       }
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
    [SerializeField] private Button _closeBut;
    private void Start()
    {
        _closeBut.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    public override void Hide()
    {
       OnShow?.Invoke();
    }

    public override void Show()
    {
        OnHide?.Invoke();
    }

   
}
