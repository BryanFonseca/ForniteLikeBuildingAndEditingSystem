using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguidorCamara : MonoBehaviour {

	public Transform camara;
	public Transform PosicionDeseada;

	public float MultiplicadorVelocidad = 2f;


	void Start()
	{
	}
	void Update () 
	{
		Seguimiento();
	}

	void Seguimiento()
	{
		camara.rotation = Quaternion.Lerp(camara.rotation, PosicionDeseada.rotation, Time.deltaTime * MultiplicadorVelocidad);
		camara.position = Vector3.Lerp(camara.position, PosicionDeseada.position, Time.deltaTime * MultiplicadorVelocidad);
	}

}
