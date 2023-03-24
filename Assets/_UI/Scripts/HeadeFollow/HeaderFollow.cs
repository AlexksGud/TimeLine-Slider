using System;
using System.Collections;
using UnityEngine;

public class HeaderFollow : MonoBehaviour
{
    [SerializeField] private float _followSpeed;
    [SerializeField, Range(-45  , 45)] 
    private float _leftBorder;

    private Vector3 _startLocalPos;
    private float constY;

    private bool _follow;

    [SerializeField] private float _clampMin, _clampMax;
    
    void Start()
    {
        constY = transform.position.y;
        _startLocalPos = new Vector3(transform.localPosition.x,transform.localPosition.y,0);
    }
  
    void Update()
    {
        if (!_follow) 
            return;

        var current = transform.position.x;
        var dX = Mathf.Lerp(current, _leftBorder, Time.deltaTime * _followSpeed);


        var newPos = new Vector3(dX, constY, 0);

        if (IsClamped()) 
            return;

        transform.position = newPos;

        bool IsClamped()
        {    
            var vecForCheck = transform.localPosition.x + dX;

            if (vecForCheck <= _clampMax && vecForCheck > _clampMin)
                return false;
                
            if (vecForCheck <= _clampMin && dX < 0)
                return false;

            if (vecForCheck > _clampMax && dX > 0)
                return false;


            return true;
               
        }
    }

    public void StartFollow()
    {
        _follow = true;
        StopCoroutine(nameof(ReturnToLocalStart));
    }
    public void StopFollow()
    {
        _follow = false;
        StartCoroutine(ReturnToLocalStart());
    }

    private IEnumerator ReturnToLocalStart()
    {
        //Ждем когда не будет видно хедер
        while (MathF.Abs(transform.position.x) < 80)
            yield return null;


        //Выпускаем его на старт
        float result = float.MaxValue;
        while (result < 0.01f)
        {
            var current = transform.position.x;
                result = Mathf.Lerp(current, _leftBorder, Time.deltaTime * _followSpeed);

            transform.position = new Vector3(result, constY, 0);
            yield return null;
        }
      
    }
}
