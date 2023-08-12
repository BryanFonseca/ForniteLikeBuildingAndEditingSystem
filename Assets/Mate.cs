using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mate : MonoBehaviour {

	public float a;
	public float b;
	public float delta;
	public float c;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		c = Mathf.MoveTowards(a, b, Time.deltaTime);
		print(a);
	}
}
