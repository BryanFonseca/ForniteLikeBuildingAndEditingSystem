using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivaADis : MonoBehaviour 
{
    public float distanciaAccion;
    public Transform objeto;

    public GameObject[] objetosDesaparecen;

    private void Update()
    {
        float distancia;
        distancia = Vector3.Distance(transform.position, objeto.position);

        if (distancia <= distanciaAccion)
        {
            for (int i = 0; i < objetosDesaparecen.Length; i++)
            {
                objetosDesaparecen[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < objetosDesaparecen.Length; i++)
            {
                objetosDesaparecen[i].SetActive(true);
            }
        }
    }
}
