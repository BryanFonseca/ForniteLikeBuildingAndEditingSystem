using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProteccionParedes : MonoBehaviour {

	public Transform PuntoAcercamiento;
	public Transform PosicionInicial;
	//public Transform direccionRayo;

	private Vector3 direccion;
	public float distancia;
	public float distanciaAccion;

	public bool EstaProtegiendo = false;
	private Vector3 posicionConDesfase;
	public float Desfase = .25f;

	public Transform camara;
	public float MultiplicadorVelocidad = 4f;

	void Start()
	{ 
		distanciaAccion = Vector3.Distance(transform.position, PuntoAcercamiento.position);
	}

	private void Update()
	{
		DeteccionParedes();
	}

	void DeteccionParedes()
	{
		distancia = Vector3.Distance(transform.position, PuntoAcercamiento.position);
		direccion = gameObject.transform.position - PuntoAcercamiento.transform.position;
		RaycastHit hit;
		if (Physics.Raycast(PuntoAcercamiento.position, direccion, out hit, distanciaAccion))
		{
			if (hit.collider.tag == "Protegido")
			{
				print(hit.collider.gameObject.name);
				Debug.DrawLine(PuntoAcercamiento.position, hit.point);
				Vector3 pos = PuntoAcercamiento.forward;
				//Debug.Log(pos);
				transform.position = Vector3.Lerp(transform.position, hit.point, Time.deltaTime * MultiplicadorVelocidad);
				EstaProtegiendo = true;
			}
			else
			{
				EstaProtegiendo = false;
			}
		}
		else
		{
			transform.position = Vector3.Lerp(transform.position, PosicionInicial.position, Time.deltaTime * 10);
			EstaProtegiendo = false;
		}

		if(!EstaProtegiendo)
			transform.position = Vector3.Lerp(transform.position, PosicionInicial.position, Time.deltaTime * 5);
	}
}
