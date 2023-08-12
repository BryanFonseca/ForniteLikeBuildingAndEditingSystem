using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posicion : MonoBehaviour {

	[HideInInspector]
	public List<Vector3> posiciones;
	private int indice = 0;

	public Transform Jugador;
	[Range(0, 1)]
	public float distanciaDeLlegada = 0.1f;
	public float MultiplicadorVelocidad = 2;

	public bool LinearInterpolation;	
	
	void Update () 
	{
		Ray rayo = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);		
		RaycastHit hit;

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{					
			if (Physics.Raycast(rayo, out hit))
			{
				StopAllCoroutines();
				indice++;
				posiciones.Add(hit.point);			
				MoverHacia(posiciones[indice-1]);				
			}			
		}		
	}

	void MoverHacia(Vector3 hacia)
	{
		StartCoroutine("Movimiento");
	}

	IEnumerator Movimiento()
	{
		while ((Jugador.position - posiciones[indice - 1]).magnitude > distanciaDeLlegada)
		{
			Vector3 posicionAInterpolar = new Vector3(posiciones[indice - 1].x, Jugador.position.y, posiciones[indice - 1].z);

			if(LinearInterpolation)
				Jugador.position = Vector3.Lerp(Jugador.position, posicionAInterpolar, Time.deltaTime * MultiplicadorVelocidad);
			else
				Jugador.position = Vector3.MoveTowards(Jugador.position, posicionAInterpolar, Time.deltaTime * MultiplicadorVelocidad * 3);

            #region MATHF
            /*
			float xTemp = Jugador.position.x;
			float yTemp = Jugador.position.y;
			float zTemp = Jugador.position.z;

			xTemp = Mathf.MoveTowards(xTemp, posicionAInterpolar.x, Time.deltaTime * MultiplicadorVelocidad);
			yTemp = Mathf.MoveTowards(yTemp, posicionAInterpolar.y, Time.deltaTime * MultiplicadorVelocidad);
			zTemp = Mathf.MoveTowards(zTemp, posicionAInterpolar.z, Time.deltaTime * MultiplicadorVelocidad);

			Vector3 ahi = new Vector3(xTemp, yTemp, zTemp);

			Jugador.position = ahi;
			 */
            #endregion 
            yield return null;
		}		
		Debug.Log("Se ha terminado la interpolación.");		
	}	
}
