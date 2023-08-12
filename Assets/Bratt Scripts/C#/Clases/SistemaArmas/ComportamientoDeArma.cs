using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoDeArma : MonoBehaviour 
{
	public Arma arma;

	void Start () 
	{
		arma.CantidadActualBalas = arma.CantidadBalasMax;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0)) Disparar();

		if (Input.GetKeyDown(KeyCode.R) && arma.CantidadActualBalas < arma.CantidadBalasMax)
		{
			arma.CantidadActualBalas = arma.CantidadBalasMax;
		}
	}
	
	void Disparar () 
	{
		if(arma.CantidadActualBalas > 0)
		arma.CantidadActualBalas--;
	}
}
