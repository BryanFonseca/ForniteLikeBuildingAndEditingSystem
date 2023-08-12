using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuerza : MonoBehaviour {

	private Rigidbody rb;
	public ConstantForce fuerzaConstante;

	public Vector3 esteHaciaAdelante;
	public Vector3 haciaAdelante;

	public float rapidez;
	
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		fuerzaConstante = gameObject.GetComponent<ConstantForce>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		esteHaciaAdelante = transform.forward;
		haciaAdelante = Vector3.forward;
		rapidez = rb.velocity.magnitude;
		//fuerzaConstante.force = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
		if(rb.velocity.magnitude >= 1) rb.velocity /= rb.velocity.magnitude;

	}
}
