using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CambioNombre : MonoBehaviour 
{
    public string nombre = "Bryan";

    private void Update()
    {
        if ("Soo" != nombre)
        {
            print("Diferente");
            nombre = "Soo";
        }
    }
}
