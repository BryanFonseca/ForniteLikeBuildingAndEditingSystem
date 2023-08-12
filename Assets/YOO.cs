using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class YOO : MonoBehaviour 
{
	public Transform Unidad;
	public BoxCollider thes;
	public Transform objeto;
	void Update () 
	{		
		//print(thes.ClosestPointOnBounds (objeto.position));	
		//print (Convert.ToInt32(transform.position.x % 2));
		//print ("Módulo: " + transform.position.x % 2 +"; PosX: "  + transform.position.x.ToString());
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.position += new Vector3 (1, 0, 0) * Time.deltaTime;
		}if(Input.GetKey(KeyCode.S))
		{
			transform.position += new Vector3 (-1, 0, 0) * Time.deltaTime;
		}if(Input.GetKey(KeyCode.A))
		{
			transform.position += new Vector3 (0, 0, 1) * Time.deltaTime;
		}if(Input.GetKey(KeyCode.D))
		{
			transform.position += new Vector3 (0, 0, -1) * Time.deltaTime;
		}


	}


	void Mover(Vector3 pos)
	{
		Unidad.transform.position += pos;
	}
}
