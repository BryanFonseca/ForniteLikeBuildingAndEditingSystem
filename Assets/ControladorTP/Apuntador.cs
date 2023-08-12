using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntador : MonoBehaviour 
{
    private Animator anim;
    public bool ap;

    public Transform spina;
    public Transform eje;

    /*
    public Transform manoIzquierdaIK;
    public Transform manoDerechaIK;
    public Transform codoIzquierdo;
    public Transform codoDerecho;
    */

    public Vector3 refe;
    public float rot;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ap = true;
        }
        
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            ap = false;
        }

        anim.SetBool("Apuntar", ap);
        rot = eje.eulerAngles.x * -1;
        spina.localRotation = Quaternion.AngleAxis(rot, refe);

    }
    public Vector3 hueso;
    void OnAnimatorIK()
    {
        if (ap)
        {
            Vector3 bone = anim.GetBoneTransform(HumanBodyBones.Spine).localEulerAngles;
            anim.SetBoneLocalRotation(HumanBodyBones.Spine, Quaternion.Euler(bone + spina.localEulerAngles));

            /*
            anim.SetIKHintPosition(AvatarIKHint.LeftElbow, codoIzquierdo.position);
            anim.SetIKHintPosition(AvatarIKHint.RightElbow, codoDerecho.position);
            anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, 10);
            anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 10);

            anim.SetIKPosition(AvatarIKGoal.LeftHand, manoIzquierdaIK.position);
            anim.SetIKPosition(AvatarIKGoal.RightHand, manoDerechaIK.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);


            anim.SetIKRotation(AvatarIKGoal.LeftHand, manoIzquierdaIK.rotation);
            anim.SetIKRotation(AvatarIKGoal.RightHand, manoDerechaIK.rotation);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            */
            

            return;
        }
    }
}
