using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recolectable
{
	public string Nombre;
	public string Descripcion;
	public int Identificador;

	public Recolectable()
	{ 
	}

	public Recolectable(string Nombre, string Descripcion, int Identificador)
	{
		this.Nombre = Nombre;
		this.Descripcion = Descripcion;
		this.Identificador = Identificador;
	}
}
