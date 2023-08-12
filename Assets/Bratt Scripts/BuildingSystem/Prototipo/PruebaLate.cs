using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaLate : MonoBehaviour 
{
    public bool editando;

    private void Update()
    {
        //print(editando);
        if (editando && Input.GetKeyDown(KeyCode.G))
        {
            print("Se ha confirmado");
        }
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            editando = !editando;
        }
    }
}
