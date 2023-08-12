using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrutina : MonoBehaviour 
{
    public Transform camara;
    public Transform puntoAcercamiento;
    public float distanciaAparecer = 2;

    private float dis;
    private Material[] mats;

    private void Start()
    {
        mats = gameObject.GetComponent<SkinnedMeshRenderer>().materials;
    }

    private void Update()
    {
        dis = Mathf.Clamp((camara.position - puntoAcercamiento.position).magnitude - 1f, 0, distanciaAparecer);

        for (int i = 0; i < mats.Length; i++)
        {
            Color colorTemp = mats[i].color;
            mats[i].color = new Color(colorTemp.r, colorTemp.g, colorTemp.b, dis);
        }
    }
}
