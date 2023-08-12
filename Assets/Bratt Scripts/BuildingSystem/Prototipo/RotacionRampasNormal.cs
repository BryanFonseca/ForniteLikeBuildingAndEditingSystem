using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionRampasNormal : MonoBehaviour 
{
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.Log(hit.normal);
            Vector3 normal = hit.normal;

            if (normal == new Vector3(0, 0, -1))
            {
                Debug.Log("Norte");
            } else if (normal == new Vector3(-1, 0, 0))
            {
                Debug.Log("Este");
            }
            else if (normal == new Vector3(0, 0, 1))
            {
                Debug.Log("Sur");
            }
            else if (normal == new Vector3(1, 0, 0))
            {
                Debug.Log("Oeste");
            }
        }
    }
}
