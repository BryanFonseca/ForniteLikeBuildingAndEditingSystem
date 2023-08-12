using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiPenetrador : MonoBehaviour {

	public Transform from;
	public Transform to;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Paredes(from.position,to.position);
	}
	void Paredes(Vector3 fromObject, Vector3 toTarget)
	{
		Debug.DrawLine(fromObject, toTarget);
		RaycastHit choquePared;
		if (Physics.Linecast(fromObject,toTarget, out choquePared))
		{
			Debug.DrawRay(choquePared.point, Vector3.left, Color.red);
			toTarget = new Vector3(choquePared.point.x, toTarget.y, choquePared.point.z);
		}
	}
}
