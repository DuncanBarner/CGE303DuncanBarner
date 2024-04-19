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
}
