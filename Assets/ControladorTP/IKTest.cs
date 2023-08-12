using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTest : MonoBehaviour {

    private Animator anim;
    public bool ikActive;
    public Transform manoIzquierdaIK;
    public Transform manoDerechaIK;
    public Transform codoIzquierdo;
    public Transform codoDerecho;
    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnAnimatorIK()
    {
        anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 1);
        anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1);
        anim.SetIKHintPosition(AvatarIKHint.LeftElbow, codoIzquierdo.position);
        anim.SetIKHintPosition(AvatarIKHint.RightElbow, codoDerecho.position);

        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        anim.SetIKPosition(AvatarIKGoal.LeftHand, manoIzquierdaIK.position);
        anim.SetIKPosition(AvatarIKGoal.RightHand, manoDerechaIK.position);
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);

        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, manoIzquierdaIK.rotation);
        anim.SetIKRotation(AvatarIKGoal.RightHand, manoDerechaIK.rotation);
    }
}
