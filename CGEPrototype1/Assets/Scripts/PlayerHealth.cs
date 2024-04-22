using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    //Variable to set player health
    public int health = 100;

    //Reference to the health bar
    public DisplayBar healthBar;

    private Rigidbody2D rb;

    //Knockback force when the player collides with an enemy
    public float knockbackForce = 5f;

    //Prefab to spawn when the player dies
    public GameObject playerDeathEffect;

    //Bool to track if the player has recently been hit
    public static bool hitRecently;

    //Time in seconds to recover from being hit
    public float hitRecoveryTime = 0.2f;
    
    
    void Start()
    { 
        //Set the rigidbody reference
        rb = GetComponent<Rigidbody2D>();

        //Check if rb is assigned in inspector
        if(rb == null)
        {
            Debug.LogError("RigidBody2D component not found on player!!");
        }
        
        //Set the max value of the health bar to the player's health
        healthBar.SetMaxValue(health);

        //Initialize hitRecently to false
        hitRecently = false;

    }


    //A function to knockback player when hit
    public void Knockback(Vector3 enemyPosition)
    {
        //If the player has been recently hit, return
        if (hitRecently)
        {
            return;
        }
        //Set the hitRecently bool to true because we've now been hit
        hitRecently = true;

        //Start coroutine to recover from being hit
        StartCoroutine(RecoverFromHit());

        /*
         Calculate direction of the knockback by using Vector2 to draw an arrow
        from enemy to the player 
        */
        Vector2 direction = transform.position - enemyPosition;

        /* 
        Normalize the direction of the vector
        This gives a consistent knockback force regardless of the distance
        from the enemy to player 
        */
        direction.Normalize(); //Sets length to 1

        //Add upward force to the knockback
        direction.y = direction.y * 0.5f + 0.5f;

        //Apply the knockback force. Add force to player in direction of knockback
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
        //Impulse is used when you have a momentary force being applied (like a jump or a hit)

    }

    //Coroutine to recover from being hit (resets hitRecently bool after delay)
    IEnumerator RecoverFromHit()
    {
       //Wait for hitRecoveryTime seconds
        yield return new WaitForSeconds(hitRecoveryTime);

        //set hitRecently to false
        hitRecently = false;
    }


    //Function to take damage
    public void TakeDamage(int damage)
    {
        //subtract damage from player's health
        health -= damage;

        //update health bar
        healthBar.SetValue(health);

        //TODO: Play sound effect when damaged
        //TODO: Play animation when the player takes damage


        //Die function
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Set gameover in ScoreManager to true
        ScoreManager.gameOver = true;

        //TODO: Play sound effect when player dies
        //TODO: Add player death effect when player dies

        //Disable player object
        gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
