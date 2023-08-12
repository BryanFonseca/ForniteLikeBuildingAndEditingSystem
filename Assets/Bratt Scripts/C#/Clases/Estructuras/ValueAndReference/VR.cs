using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR : MonoBehaviour
{
	public string Nombre;
	public int Edad;

	void Start()
	{
		Nombre = "Bryan";
		Edad = 18;

		/*
		print(Suma(Edad));
		print(Edad);
		*/

		print(CambiarNombre(Nombre));
		print(Nombre);
	}

	int Suma(int valor)
	{
		valor = valor + 1;
		return valor;
	}

	string CambiarNombre(string nombre)
	{
		nombre = "Isaac";
		return nombre;
	}
	
}
