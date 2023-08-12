using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarColision : MonoBehaviour 
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ParedC")
            print("Colisionó");
    }

}
