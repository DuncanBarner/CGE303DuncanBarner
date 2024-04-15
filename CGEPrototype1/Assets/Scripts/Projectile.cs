using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //projectile's rigidbody
    private Rigidbody2D rb;

    public float speed = 20f;


    //damage the projectile will deal with default of 20
    public int damage = 20;

    //impact animation effect for projectile once it collides with something
    public GameObject impactEffect;



    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        //set the velocity of the projectile to move right
        rb.velocity = transform.right * speed;
        
        
    }

    //When the projectile collides with an object
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        //If object that was hit is of type Enemy
        if (enemy != null)
        {
            enemy.TakeDamage(damage);

        }
        //If the object that was hit is not the player
        if(hitInfo.gameObject.tag != "Player")
        {


            //Instantiate impact effect
            Instantiate(impactEffect, transform.position, Quaternion.identity);



            //destroy projectile
            Destroy(gameObject);
        }


    }


}
