using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// This is a basic 2D player controller featuring horizontal movement, jumping, and setting up of various aspect in-script such as rigidbody2d.
/// 
/// </summary>


public class PlayerController : MonoBehaviour
{

    //define and initialise variables
    [SerializeField]
    public float moveSpeed = 5f;

    [SerializeField]
    public float jumpForce = 6f;
    
    private bool isJumping = false;
    private Rigidbody2D rigidBody;
    private Vector3 spawnPos;




    void Start()
    {
        //get and attach the rigid body to the player's (the parent object's) rigid body
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.freezeRotation = true;
        SetPlayerSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        //call any and all relevent functions
        Movement();
    }

    //function to control movement of parent object (player)
    private void Movement()
    {
        //horizontal (left & right) movement
        var moveX = Input.GetAxis("Horizontal"); //get axis of movement (direction of movement)
        rigidBody.velocity = new Vector2((moveX * moveSpeed), rigidBody.velocity.y); //update velocity (movement in a direction) with a new vector2 (vector 2 is (x, y) coordinates)
        

        //vertical movement (jump -> up and down)
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); //apply an upwards impulse (an impulse is a force that happens suddenly. Like a push. Rather than a constant force such as a car moving foward)
            isJumping = true; //update bool check
        }
    }

    public void ResetPlayerPos()
    {
        transform.position = spawnPos;
    }
    
    public void SetPlayerSpawn()
    {
        spawnPos = transform.position;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        //check if the collision was with the ground   -   NOTE: make sure platforms have a tag "Ground", this is set in the top of the inspector.
        if (collision.gameObject.CompareTag("Ground"))
        {
            //if they do, the player is no longer jumping
            isJumping = false;
        }
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            this.transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        }

        if (collision.gameObject.CompareTag("Hazard"))
        {
            ResetPlayerPos();
        }
    }
}