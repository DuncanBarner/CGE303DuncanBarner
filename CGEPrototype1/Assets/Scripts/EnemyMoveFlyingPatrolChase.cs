using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveFlyingPatrolChase : MonoBehaviour
{
    //Array of waypoints the enemy moves between
    public GameObject[] patrolPoints;

    //Current patrol point index
    private int currentPatrolPointIndex = 0;


    //Public movement variables
    public float speed = 2f;
    public float chaseRange = 3f;

    //Enemy state enum
    public enum EnemyState //Creates a new type that can ONLY be one of the things listed below
    {
        PATROLLING,
        CHASING
    }

    //Enemy state variable for enemy's current state
    public EnemyState currentState = EnemyState.PATROLLING;

    //Variables for targeting the player and then move to
    public GameObject target;
    private GameObject player;

    //RigidBody2D component for enemy
    private Rigidbody2D rb;

    //Sprite renderer for the enemy
    private SpriteRenderer sr;

   

    // Start is called before the first frame update
    void Start()
    {
        //Find the player object
        player = GameObject.FindWithTag("Player");

        //Get the RigidBody2D component
        rb = GetComponent<Rigidbody2D>();

        //Get sprite renderer component
        sr = GetComponent<SpriteRenderer>();

        //Check if the patrolPoints array is empty
        if(patrolPoints == null || patrolPoints.Length <1)
        {
            Debug.LogError("Patrol points are not set up for octopus");
        }

        //Set the target for first patrol point
        target = patrolPoints[currentPatrolPointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        //Update the state based on player and target distance
        UpdateState();

        //Move and face based on current state
        switch (currentState)
        {
            case EnemyState.PATROLLING:
                Patrol();
                break;
            case EnemyState.CHASING:
                ChasePlayer();
                break;
        }
        //Draws line from enemy to target in scene view
        Debug.DrawLine(transform.position, target.transform.position, Color.red);
        
    }

    void UpdateState()
    {
        if(IsPlayerInChaseRange() && currentState == EnemyState.PATROLLING)
        {
            currentState = EnemyState.CHASING;
        }
        else if(!IsPlayerInChaseRange() && currentState == EnemyState.CHASING)
        {
            currentState = EnemyState.PATROLLING;
        }
    }
    bool IsPlayerInChaseRange()
    {
        if(player == null)
        {
            Debug.LogError("Player not found");
            return false;
        }

        float distance = Vector2.Distance(transform.position, player.transform.position);
        return distance <= chaseRange;
    }

    void Patrol()
    {
        //Check if reached current target
        if(Vector2.Distance(transform.position, target.transform.position) <= 0.5f)
        {
            //Update the target to next patrol point (wrap around)
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
        }

        //Set target to current patrol point
        target = patrolPoints[currentPatrolPointIndex];
        MoveTowardsTarget();
    }

    void ChasePlayer()
    {
        target = player;
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        //Calculate direction towards target
        Vector2 direction = target.transform.position - transform.position;

        //Normalize direction (direction without length of the arrow)
        //This normalizes speed so it's not faster when it's further away
        direction.Normalize();

        //Move towards target with rb
        rb.velocity = direction * speed;

        //Face forward
        FaceForward(direction);
    }

    private void FaceForward(Vector2 direction)
    {
        if(direction.x < 0)
        {
            sr.flipX = false;
        }
        else if(direction.x > 0)
        {
            sr.flipX = true;
        }
    }

    //Draw circles for patrol points in the scene view
    private void OnDrawGizmos()
    {
        if(patrolPoints != null)
        {
            Gizmos.color = Color.green;
            foreach(GameObject point in patrolPoints) 
            {
                Gizmos.DrawWireSphere(point.transform.position, 0.5f); //0.5f is the radius

            }
        }
    }


}
