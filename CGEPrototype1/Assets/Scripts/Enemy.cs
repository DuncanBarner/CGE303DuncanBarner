using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy Health
    public int health = 100;

    //A prefab to spawn when the enemy dies
    public GameObject deathEffect;


    public void TakeDamage(int damage)
    {
        //subtract the damage dealt from health
        health -= damage;

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
