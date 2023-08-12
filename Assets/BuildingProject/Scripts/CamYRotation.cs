using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamYRotation : MonoBehaviour {

	private float mouseY;

	public GameObject Bala;

	public float Fuerza = 50f;
	//public Transform parent;

	void Update()
	{
		mouseY = Mathf.Clamp (mouseY - Input.GetAxis("Mouse Y"), -75, 75);

		transform.rotation = Quaternion.Euler(new Vector3(mouseY,transform.rotation.eulerAngles.y,0));

		if (Input.GetKeyDown (KeyCode.Space))
			Disparar ();
	}

	void Disparar()
	{

		GameObject instancia = Instantiate (Bala,this.transform.position,this.transform.rotation);
		instancia.GetComponent<Rigidbody> ().AddForce (instancia.transform.forward * Fuerza, ForceMode.Impulse);
	}
}
