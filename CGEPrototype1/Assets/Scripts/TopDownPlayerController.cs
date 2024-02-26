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
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");


        
    }

     void FixedUpdate()
    {
        //Move the player using RigidBody2D in FixedUpdate
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);


        
    }


}
