using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCLearnings : MonoBehaviour {

	public Vector3 miVector;
	public Vector3 miOtroVector;
	public Vector2 mivector2;

	public Vector3 proyectado;
	public Vector3 normal;

	public Transform plano;
	public Transform VectorAProyectar;

	public Vector3 ProyeccionGrafica;

	public Transform miTransform;

	public float magnitud;
	void Start()
	{
		//miVector.Normalize();
		mivector2.Normalize();
		//normal = Vector3.up;

		
		//miOtroVector = miTransform.TransformDirection(;
		//magnitud = miVector.magnitude;
	}
	void Update()
	{
		//miVector = miTransform.InverseTransformVector(miTransform.position);
		miTransform.InverseTransformVector(miTransform.position);
		proyectado = Vector3.ProjectOnPlane(miVector, normal);

		ProyeccionGrafica = Vector3.ProjectOnPlane(VectorAProyectar.position, plano.position);
		
	}	
}
