using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerAlAcercar : MonoBehaviour 
{
    //Debe ser asignada al objeto que contenga los materiales que desaparecerán

    public Transform camara;
    public Transform puntoAcercamiento;
    public float distanciaAparecer = 1;

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
            mats[i].color = new Color(colorTemp.r, colorTemp.g, colorTemp.b, dis / distanciaAparecer);
        }
    }
}
