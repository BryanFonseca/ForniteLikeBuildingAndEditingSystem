using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPC : MonoBehaviour 
{
	private float v;
	private float h;
	private float mouseX;

	public float sensibilidad;
	public float velocidad = 5;
	
	void Update () 
	{
		v = Input.GetAxis ("Vertical");		
		h = Input.GetAxis ("Horizontal");	

		mouseX += Input.GetAxis ("Mouse X");
		transform.Translate (new Vector3 (h, 0, v) * Time.deltaTime * velocidad);
		transform.rotation = Quaternion.Euler(new Vector3 (0, mouseX, 0));
	}
}
