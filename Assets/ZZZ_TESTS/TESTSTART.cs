using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTSTART : PARENTTEST
{
    // Start is called before the first frame update
    void Start()
    {
        print("Hello son start");
    }

   
}
public class PARENTTEST : MonoBehaviour
{
    private void Awake()
    {
        print("Hello parent awake");
    }
    private void Start()
    {
        print("Hello parent start");
    }
}
