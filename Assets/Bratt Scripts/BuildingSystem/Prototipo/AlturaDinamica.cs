using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlturaDinamica : MonoBehaviour 
{
    public GameObject[] capa1_Paredes = new GameObject[4];
    public GameObject[] capa2_Paredes = new GameObject[12];
    public GameObject[] parents = new GameObject[4];
    public static float yParedesGlobal = 0;
    public float[] distancias = new float[4];
    public Vector3 xzPunto;

    public void Ejecutar()
    {
        xzPunto = new Vector3(transform.position.x, 0, transform.position.z); //siempre se calculará

        for (int i = 0; i < distancias.Length; i++)
        {
            Vector3 tempPared = new Vector3(capa1_Paredes[i].transform.position.x, 0, capa1_Paredes[i].transform.position.z);
            distancias[i] = Vector3.Distance(xzPunto, tempPared);
            distancias[i] /= 7f;
        }

        for (int i = 0; i < capa1_Paredes.Length; i++)
        {
            float interpolacionY;
            if (gameObject.GetComponent<SistemaConstruccion_01>().mostrarRampas)
                //interpolacionY = Mathf.Lerp(-.8f, -.5f, distancias[i]);
                interpolacionY = -1;
            else
            {
                interpolacionY = Mathf.Lerp(-.75f, 0, distancias[i]);
            }
            parents[i].GetComponent<BoxCollider>().center = new Vector3(0, interpolacionY, 0);            
        }
    }

    public void AlturaOnRampas(bool valor)
    {
        if (valor)
        {
            for (int i = 0; i < capa2_Paredes.Length; i++)
            {
                capa2_Paredes[i].GetComponent<BoxCollider>().size = new Vector3(1, 2, 1);
                capa2_Paredes[i].GetComponent<BoxCollider>().center = new Vector3(0, -.5f, 0);
            }
        }
        else
        {
            for (int i = 0; i < capa2_Paredes.Length; i++)
            {
                capa2_Paredes[i].GetComponent<BoxCollider>().size = new Vector3(1, 1, 1);
                capa2_Paredes[i].GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
            }
        }
    }
}
