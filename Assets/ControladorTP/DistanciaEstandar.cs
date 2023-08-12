using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DistanciaEstandar : MonoBehaviour 
{
    public bool x;

    private void Update()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (x)
            gameObject.transform.position = new Vector3(playerPos.x, gameObject.transform.position.y, gameObject.transform.position.z);
        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, playerPos.z);
        }
    }
}
