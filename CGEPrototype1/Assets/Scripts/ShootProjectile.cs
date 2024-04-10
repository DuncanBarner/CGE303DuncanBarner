using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    //projectile prefab to be spawned
    public GameObject projectilePrefab;

    //reference to the fire point transform
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player presses the fire button
        if (Input.GetButtonDown("Fire1")){
            //Call shoot method
            Shoot();

        }
        
    }

    void Shoot()
    {
        //Instantiates the projectile at the firepoint's position and rotation
        GameObject PlayerProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        //Destroy after 3 seconds
        Destroy(PlayerProjectile, 3f);
    }
}
