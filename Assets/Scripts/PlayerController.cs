using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;
    int score = 0;
    Vector3 lastPosition;

    //Movment
    public float speed = 5f, jumpVelocity = 10f;
    public LayerMask playerMask;
    Transform myTrans, tagGround;

    //Combat
    public int health = 3;
    public float invisibleTimeAfterHurt = 2;

    Rigidbody2D myBody;
    float hInput = 0;

    bool isGrounded = false;


	// Use this for initialization
	void Start () {
        instance = this;
        myBody = this.GetComponent<Rigidbody2D>();
        myTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        lastPosition = this.transform.position;
        
}
	
	// Update is called once per frame
	void FixedUpdate () {
        isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);

        Move(Input.GetAxisRaw("Horizontal"));
         if (Input.GetButtonDown("Jump"))
             Jump();

         //Włączyć, żeby działało na Androidzie
        Move(hInput);

        if ((this.transform.position.x - lastPosition.x) > 0)
            score++;
        else if ((this.transform.position.x - lastPosition.x) < 0)
            score--;

        lastPosition = this.transform.position;
    }

    void Move(float horizontalInput)
    { 
        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizontalInput * speed;
        myBody.velocity = moveVel;
    }

    public void Jump()
    {
        if(isGrounded)
            myBody.velocity += jumpVelocity * Vector2.up;
    }

    public void StartMoving(float horizontalInput)
    {
        hInput = horizontalInput;
    }

    void Hurt()
    {
        Debug.Log("Hit");
        health--;
        if (health <= 0)
            Application.LoadLevel("Game Over");
    }
    void OnCollisionEnter2d(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Cactuse")
        {
            Hurt();
        }
    }
    private GUIStyle guiStyle = new GUIStyle();

    void OnGUI()
    {
        GUI.contentColor = Color.red;
        GUI.Label(new Rect(Screen.width / 2 - 30, 500, 100, 100), "Score : " + score);
    }
}
