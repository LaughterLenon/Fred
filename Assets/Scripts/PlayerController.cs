using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public float speed = 500, jumpHeight = 500;
    Transform myTrans;
    Rigidbody myBody;
    Vector3 movement;
    bool isGrounded = true;

	// Use this for initialization
	void Start () {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
	}

    void Move (float horizontal_input)
    {
        movement = myBody.velocity;
        if (isGrounded) {
            movement.x = horizontal_input * speed * Time.deltaTime;
        }

        myBody.velocity = movement;
    }

    void Jump()
    {
        if (isGrounded)
        {
            myBody.velocity += (jumpHeight * Vector3.up * Time.deltaTime);
        }
    }

}
