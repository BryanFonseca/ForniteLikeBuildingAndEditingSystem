using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHelper : MonoBehaviour {

    public float tiempoEmpezoAInterpolar;
    public float tiempoDeInterpolacion;

    public Vector3 endPosition;
    public Vector3 startPosition;

    public float tiempoDesdeEmpezo;
    public float porcentaje;

    private void StartLerping()
    {
        tiempoEmpezoAInterpolar = Time.time;

    
    }

    // Start is called before the first frame update
    void Start()
    {
        //startPosition = transform.position;
        StartLerping();
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoDesdeEmpezo = Time.time - tiempoEmpezoAInterpolar;
        porcentaje = tiempoDesdeEmpezo / tiempoDeInterpolacion;
        transform.position = Vector3.Lerp(startPosition, endPosition, Time.time/2);
        
    }
    
}
