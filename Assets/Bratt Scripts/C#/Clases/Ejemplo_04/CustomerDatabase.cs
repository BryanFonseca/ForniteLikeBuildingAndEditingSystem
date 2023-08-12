using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDatabase : MonoBehaviour 
{
	public Customer Bryan;
	public Customer Ange;
	public Customer Cris;

	public Customer[] Personas;

	public Customer Scope = new Customer("Scope", "", "", "", 1);

	void Start()
	{
		Bryan = new Customer("Bryan", "Fonseca", "M", "Ing", 18);
		Ange = new Customer("Ange", "Ur", "F", "Gordi", 6);
		Cris = new Customer("Cris", "Toala", "F", "Muahh", 19);
	}
}
