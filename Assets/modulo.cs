using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class modulo : MonoBehaviour 
{
    float valor;

    void Update()
    {
        print(transform.position.x % 2);        
    }
}
