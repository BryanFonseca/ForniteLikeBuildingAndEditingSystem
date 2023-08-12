using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolacion : MonoBehaviour {

	[Range(0f, 1f)]
	public float t;

	public float a;
	public float b;

	public float interpolacion;

	public float temporizadordelta;
	public float temporizador;
	void Update()
	{
		temporizadordelta += Time.deltaTime;
		temporizador = Time.time;
		interpolacion = Mathf.Lerp(a, b, Time.time/5);
	}
}
