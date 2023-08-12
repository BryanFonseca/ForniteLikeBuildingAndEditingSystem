using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour {

	public string Name;
 

	protected virtual void Speak()
	{
		Debug.Log("Speak!");
	}

	void Start()
	{
		Speak();
	}
}
