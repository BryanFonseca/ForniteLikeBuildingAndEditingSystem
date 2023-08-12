using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCBuilder : ControladorTerceraPersona{
	FortniteBuildingController buildBehavior;
	bool canBuild;

	void Start () {
		buildBehavior = gameObject.GetComponent<FortniteBuildingController>();
	}
	
	new void Update () {
		base.Update();
		if (Input.GetKeyDown(KeyCode.Space)) {
			canBuild = !canBuild;
            GetAnimator().SetBool("Construyendo", canBuild);
			buildBehavior.build();
		}
	}
}
