using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modul : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        decimal c = (decimal)gameObject.transform.position.x;
        if (c % 2 == 0)
        {
            print("something");
        }
    }
}
