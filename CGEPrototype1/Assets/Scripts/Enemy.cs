using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy Health
    public int health = 100;

    //A prefab to spawn when the enemy dies
    public GameObject deathEffect;

    //Create a reference to the healthbar
    private DisplayBar healthBar;

    //Damage that the enemy deals to the player
    public int damage = 10;

    private void Start()
    {
        //Find the health bar in the children of the enemy
        healthBar = GetComponentInChildren<DisplayBar>();

       //Debug statement to output message if we forget to set the reference
        if(healthBar == null)
        {
            Debug.LogError("Health bar (DisplayBar script) not found!!");
            return;
        }
        healthBar.SetMaxValue(health);
    }


    public void TakeDamage(int damage)
    {
        //subtract the damage dealt from health
        health -= damage;


        //Update the health bar
        healthBar.SetValue(health);

        //if health is less than or equal to 0
        if(health <= 0)
        {
            //death function
            Die();
        }
    }

    void Die()
    {
        //spawn death effect
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        //Destroy the enemy
        Destroy(gameObject);
    }

    //Function to damage player when the enemy collides with player
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            //Check if player health script is null
            if(playerHealth == null ) 
            {
                //Log error if player health script is null
                Debug.LogError("PlayerHealth script not set on player!");
                return;
            }

            //Damage the player
            playerHealth.TakeDamage(damage);

            //Knockback the player
            playerHealth.Knockback(transform.position);

        }
    }
}
