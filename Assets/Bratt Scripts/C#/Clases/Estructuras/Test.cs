using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Item2 //VALUE TYPE
{
	public string name;
	public int itemID;

	public Item2(string name, int itemID)
	{
		this.name = name;
		this.itemID = itemID;
	}
}

public class Item //REFERENCE TYPE
{
	public string name;
	public int itemID;

	public Item(string name, int itemID)
	{
		this.name = name;
		this.itemID = itemID;
	}
}

public class Test : MonoBehaviour
{
	Item sword = new Item("Sword", 1);
	Item2 bread;

	void Start()
	{
		bread.name = "Bread";
		bread.itemID = 2;

		/*
		Debug.Log("Sword: " + sword.name);
		Cambiar(sword);
		Debug.Log("Sword (after method): " + sword.name);
		*/

		Debug.Log("Bread: " + bread.name);
		Cambiar(bread);
		Debug.Log("Bread (after method): " + bread.name);
	}

	void Cambiar(Item classItem) //REFERENCE
	{
		classItem.name = "Master Sword";
	}

	void Cambiar(Item2 strucItem) //VALUE
	{
		strucItem.name = "Pan";
	}
}