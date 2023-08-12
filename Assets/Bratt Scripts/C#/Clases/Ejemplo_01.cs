using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadisticasArma
{
	public string Name;
	public float FireRate;
	public int AmmoCount;

	public EstadisticasArma(string Name, float FireRate, int AmmoCount)
	{
		this.Name = Name;
		this.FireRate = FireRate;
		this.AmmoCount = AmmoCount;
	}
}

public class Ejemplo_01 : MonoBehaviour 
{
	private EstadisticasArma blaster;
	private EstadisticasArma rocket;

	void Start()
	{
		blaster = new EstadisticasArma("Blaster", .25f, 50);
		rocket = new EstadisticasArma("Rocket", 5f, 1);

		Debug.Log("Nombre de arma actual: " + blaster.Name);
	}
	
}
