using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorGuardadoPersonaje : MonoBehaviour 
{
    private void Awake()
    {
        SSManager.guardar += EnviarDatosAGuardar;
        SSManager.cargar += RecibirDatosGuardados;
    }

    private void EnviarDatosAGuardar()
    {
        //método llamado con el evento "guardar"

        SSManager.Instance.posicionGuardada = transform.position;
    }

    private void RecibirDatosGuardados()
    {
        //método llamado con el evento "cargar"

        gameObject.transform.position = SSManager.Instance.posicionGuardada;
    }
}
