using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo_02 : MonoBehaviour {

	EstadisticasArma blaster;

	private void Start()
	{
		blaster = new EstadisticasArma("Blaster", .25f, 50);
	}

	//Si el Jugador COLISIONA con un PowerUp
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			//Actualizar interfaz gráfica o Asignar Arma
			Destroy(this.gameObject);
		}
	}
}
