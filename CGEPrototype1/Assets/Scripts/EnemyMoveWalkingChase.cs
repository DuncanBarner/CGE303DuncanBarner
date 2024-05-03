using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;


//Require a RigidBody2D and animator on the enemy
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))] 

public class EnemyMoveWalkingChase : MonoBehaviour
{
    //Range to player for chase
    public float chaseRange = 4f;
   
    //Enemy Speed
    public float enemyMovementSpeed = 1.5f;
    
    //Transform of the player
    private Transform playerTransform;

    private Rigidbody2D rb;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        //Setting private references
        rb = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get Vector2 from the enemy to the player
        Vector2 playerDirection = playerTransform.position - transform.position;

        //Distance between enemy and player
        float distanceToPlayer = playerDirection.magnitude;

        if(distanceToPlayer <= chaseRange)
        {
            playerDirection.Normalize();

            //Set y axis to 0 because we don't want to move on the y axis for this enemy movement
            playerDirection.y = 0f;

            //Rotate enemy to face player
            FacePlayer(playerDirection);

            //If there is ground ahead of the enemy
            if (IsGroundAhead())
            {
                MoveTowardsPlayer(playerDirection);
            }

            //If there is no ground ahead of the enemy
            else
            {
                StopMoving();
            }


        }
        else
        {
            StopMoving();
        }

        
    }
    bool IsGroundAhead()
    {
        //Ground check variable
        float groundCheckDistance = 2.0f; //adjust this distance as needed
        LayerMask groundLayer = LayerMask.GetMask("Ground");

        //Determine which direction the enemy is facing
        Vector2 enemyFacingDirection = transform.rotation.y == 0 ? Vector2.left : Vector2.right;

        //Raycast to check for ground ahead of the enemy
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down + enemyFacingDirection, groundCheckDistance, groundLayer);

        //Return true if ground detected
        return hit.collider != null;
    }

    private void FacePlayer(Vector2 playerDirection)
    {
        if(playerDirection.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
           
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

    private void MoveTowardsPlayer(Vector2 playerDirection)
    {
        /* Move the enemy towards the player by setting the velocity
         to a new Vector2 without changing the y axis of velocity */
        rb.velocity = new Vector2(playerDirection.x * enemyMovementSpeed, rb.velocity.y);

        //Set animator to move
        animator.SetBool("isMoving", true);

    }

    private void StopMoving()
    {
        //Stop moving if the player is out of range
        rb.velocity = new Vector2(0, rb.velocity.y);

        //Set the animator parameter to stop moving
        animator.SetBool("isMoving", false);
    }


}
