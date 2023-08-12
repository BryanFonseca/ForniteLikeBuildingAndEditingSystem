using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

class Persona
{
	public string Nombre;

	public Persona(string Nombre)
	{
		this.Nombre = Nombre;
	}
}
public class PruebaRef : MonoBehaviour 
{
	Persona persona; //asigna espacio 
	

	int a; //asigna 4 bytes de memoria (32 bits)

	void Start()
	{
		persona = new Persona("Bryan"); /*guarda una dirección que lleva a un punto en la memoria que contiene ese valor.
										  si se crease otro objeto y se igualara al primero, haría referencia a la misma dirección
										  y modificar uno, implicaría modificar otro*/

		Process proc = Process.Start("notepad.exe");
		a = 1; //asigna valor a variable

		print("El nombre es: " + persona.Nombre);
		Cambiar(persona);
		print("El nombre es: " + persona.Nombre);
	}

	void Cambiar(Persona p)
	{
		p.Nombre = "Isaac";
	}
}
