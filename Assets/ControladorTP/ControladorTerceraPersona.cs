using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTerceraPersona : MonoBehaviour 
{
    private Animator anim;
    private CharacterController charController;
    private float verticalAnimatorActivation, horizontalAnimatorActivation, mouseXAnimatorActivation;
    private Vector3 velocity;

    public bool enSuelo = true, isHittingWall = false;
    public Transform groundChecker, lookAtPoint;
    public LayerMask FloorMask, IgnoreRaycast;
    public float sensitivity = 5f, groundCheckerRadius = .4f, speed;


    private void Awake() {
        anim = gameObject.GetComponent<Animator>();
        // layer 1 is torso
        anim.SetLayerWeight(1, 1);
        charController = gameObject.GetComponent<CharacterController>();
    }

    public void Update() {
        movement();
        setAnimatorParameters();
    }

    void moveForward(float verticalActivation) {
        if (isHittingWall) {
            verticalAnimatorActivation = Mathf.Lerp(verticalAnimatorActivation, 0, Time.deltaTime * 4.5f);
            return;
        }
        verticalAnimatorActivation = Mathf.MoveTowards(verticalAnimatorActivation, verticalActivation, Time.deltaTime * 3);
    }

    void movement() {
        if (Input.GetKey(KeyCode.W)) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                moveForward(1f);
            } else {
                moveForward(0.5f);
            }
        } else if(Input.GetKey(KeyCode.S)) {
            moveForward(-1f);
        } else {
            verticalAnimatorActivation = Mathf.MoveTowards(verticalAnimatorActivation, 0, Time.deltaTime * 2);
            // verticalAnimatorActivation = Mathf.Lerp(verticalAnimatorActivation, 0, Time.deltaTime * 6); // looks good too
        }

        horizontalAnimatorActivation = Mathf.Lerp(horizontalAnimatorActivation, Mathf.Clamp(Input.GetAxis("Horizontal"), -.5f, .5f), Time.deltaTime*15);
        mouseXAnimatorActivation = Mathf.Lerp(mouseXAnimatorActivation, Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1), Time.deltaTime * 5f);

        transform.Rotate(Vector3.up * Time.deltaTime * sensitivity * Input.GetAxis("Mouse X") * 10);
        
        speed = charController.velocity.magnitude;
        wallDetection();
        groundDetection();
    }

    void wallDetection() {
        isHittingWall = false;

        RaycastHit wallHit;
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.forward, out wallHit, 1f)) {
            if (wallHit.collider.tag == "Pared" && wallHit.distance <= 1f) {
                if (speed <= 1) {
                    isHittingWall = true;
                }
            }
        }
    }

    void groundDetection() {        
        bool otroSuelo = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, IgnoreRaycast);
        enSuelo = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, FloorMask) || otroSuelo;

        if (!enSuelo) {            
            velocity += new Vector3(0, -9.8f * Time.deltaTime, 0);
        } else {
            velocity = Vector3.zero;
        }
    }

    void setAnimatorParameters()
    {
        anim.SetFloat("Vertical", verticalAnimatorActivation);
        anim.SetFloat("MouseX", mouseXAnimatorActivation);
        anim.SetFloat("Horizontal", horizontalAnimatorActivation);
        // maybe this is a good use case of strategy pattern bcs I'm not sure if my character is gonna
        // be able to build so I can't add a isBuilding property in this class nor in the buildingController
        // since that is data managed by the character

        //anim.SetBool("Cayendo",!enSuelo);
    }

    void OnAnimatorIK() {
        anim.SetLookAtWeight(1);
        anim.SetLookAtPosition(lookAtPoint.position);
    }

    public Animator GetAnimator() {
        return this.anim;
    }

}
