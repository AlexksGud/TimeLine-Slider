using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform _tl;
    [SerializeField,Range(0f,1f)] 
    private float _paralaxMultiplier;

    [SerializeField, Range(0f, 1f)]
    private float _speed;
    [SerializeField]
    private float _maxSpeed;

   void Update()
   {
       var currentPos = _tl.position.x;

        ParalaxMove(currentPos);
     

   }
    float v = 0;
    private void ParalaxMove(float current)
    {
        var pos = transform.position; 
        var result = Mathf.SmoothDamp(pos.x, current * _paralaxMultiplier, ref v, _speed, _maxSpeed); // для плавности при начале движения
       
        transform.position = new Vector3(result, pos.y, pos.z);


    }

}
