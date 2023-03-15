using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Paralax : MonoBehaviour
{
   [SerializeField] private Transform _tl;
   [SerializeField,Range(0f,1f)] 
   private float _paralaxMultiplier;

   private float lastpos;
   void Update()
   {
      var currentPos = _tl.position.x;

      if(lastpos != currentPos)
      {
        ParalaxMove(currentPos);
      }
        lastpos = currentPos;

    }
   private void ParalaxMove(float current)
   {
        var pos = transform.position;
        var delta = lastpos - current;
        delta *= _paralaxMultiplier;
        transform.position = new Vector3(pos.x - delta, pos.y, pos.z);


   }

}
