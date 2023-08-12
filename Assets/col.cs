using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col : MonoBehaviour 
{
	public BoxCollider thes;
	public Transform player;

	void Update ()
	{
		print(thes.ClosestPointOnBounds (player.localPosition));	
		if(thes.ClosestPointOnBounds (player.localPosition).x == 1.5f)
		{
			gameObject.transform.localPosition += new Vector3 (3, 0, 0);
		}
		if(thes.ClosestPointOnBounds (player.localPosition).x == -1.5f)
		{
			gameObject.transform.localPosition += new Vector3 (-3, 0, 0);
		}
	}
}
