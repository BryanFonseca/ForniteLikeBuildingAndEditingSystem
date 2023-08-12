using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour {

	[HideInInspector] public float y;

	private Vector3 rotacion;
	public Transform eje;
	public Transform jugador;
	public float sensibilidadY;
	
	void Update () {
		rotacion = new Vector3(-y, jugador.rotation.eulerAngles.y, jugador.rotation.eulerAngles.z);
		y = Mathf.Clamp(Input.GetAxis("Mouse Y") * Time.deltaTime * 10 * sensibilidadY + y, -70, 70);
		eje.rotation = Quaternion.Euler(rotacion);
	}
}
