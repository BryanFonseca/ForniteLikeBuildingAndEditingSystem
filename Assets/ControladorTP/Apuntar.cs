using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntar : MonoBehaviour {

	public Transform PuntoAnteapuntar;
	public Transform PuntoApuntar;
	public float MultiplicadorVelocidad = 10f;


	void Update () 
	{
	
		if (Input.GetKey(KeyCode.Mouse1))
		{
			gameObject.transform.position = Vector3.Lerp(transform.position, PuntoApuntar.position, Time.deltaTime * MultiplicadorVelocidad);
		}
		else
		{
			gameObject.transform.position = Vector3.Lerp(transform.position, PuntoAnteapuntar.position, Time.deltaTime * MultiplicadorVelocidad);
		}
	}
}
