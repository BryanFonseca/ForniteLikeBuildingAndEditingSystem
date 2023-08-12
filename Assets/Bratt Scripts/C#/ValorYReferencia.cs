using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValorYReferencia : MonoBehaviour 
{
	public int numero1 = 5;
	public string cadena1 = "Bryan";

	void Start()
	{
		print("El valor inicial de numero1 es: " + numero1);
		//Ingreso de variable que se desea cambiar
		Cambiar(ref numero1);
		print("El valor de numero1 es: " + numero1);

		print("Valor inicial de la cadena: " + cadena1);
		Cambiar(ref cadena1);
		print("Valor final de la cadena: " + cadena1);

		print(Numeros(1, 2, true));
		print(Numeros(1, 2, false));
		Comprobar(2);


	}

	void Cambiar(ref int num)
	{
		num = 4;
	}
	void Cambiar(ref string cad)
	{
		cad = "Isaac";
	}

	int Numeros(int num1, int num2, bool retorno)
	{	

		if (retorno)
		{
			return num1;
		}
		else
		{
			return num2;
		}
	}

	void Comprobar(int num)
	{
		if (num == 1)
		{
			return;
		}

		print("No es igual");
	}
}
