using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class PlatformerPlayerController : MonoBehaviour
{

    public float moveSpeed = 5f; //movement speed
    public float jumpForce = 10f; //force applied when jumping
    public LayerMask groundLayer; // layermask for detecting ground
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isGrounded;


    //Audio clip
    public AudioClip jumpSound;

    //Audio Source to play our sounds
    private AudioSource playerAudio;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerAudio = GetComponent<AudioSource>();

        if(groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller");


        }

        
    }

    // Update is called once per frame
    void Update()
    {
        //gets input values for horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");

        //Check for jump input
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //apply upward force for jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            playerAudio.PlayOneShot(jumpSound, 1.0f);


        }

    }

     void FixedUpdate()
    {
        //moves the player using Rigidbody2D in FixedUpdate
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        //Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


    }
}
