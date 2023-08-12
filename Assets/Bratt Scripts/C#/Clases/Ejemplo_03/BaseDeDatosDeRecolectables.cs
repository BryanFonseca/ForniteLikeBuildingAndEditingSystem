using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeDatosDeRecolectables : MonoBehaviour 
{
	public Recolectable Espada;
	public Recolectable Martillo;
	public Recolectable Pan;


	public Recolectable[] Inventario;

	void Start()
	{
		Espada = new Recolectable();
		Espada.Nombre = "Espada";
		Espada.Descripcion = "Esta es una Espada!";
		Espada.Identificador = 1;

		Martillo = new Recolectable("Martillo", "Este es un Martillo!", 2);

		Pan = CrearRecolectable("Pan", "Esto es un pan", 3);
	}

	Recolectable CrearRecolectable(string Nombre, string Descripcion, int Identificador)
	{
		var recolectable = new Recolectable(Nombre, Descripcion, Identificador);
		return recolectable;
	}
}
