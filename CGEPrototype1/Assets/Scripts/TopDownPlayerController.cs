using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    //adjust value in inspector to set players movespeed
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 movement;




    // Start is called before the first frame update
    void Start()
    {
        //Get the RigidBody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();


        
    }

    // Update is called once per frame
    void Update()
    {
        //Get input values for horizontal and vertical movement
        //GetAxisRaw so the input is either 1, 0, or -1
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Normalize the movement when moving diagonally
        //to prevent faster diagonal movement compared to
        //normal 4-directional movement
        movement.Normalize();
        
    }

     void FixedUpdate()
    {
        //Move the player using RigidBody2D in FixedUpdate
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);


        
    }


}
