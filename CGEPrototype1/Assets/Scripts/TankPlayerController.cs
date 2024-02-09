using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerController : MonoBehaviour
{
    //setting this to 8 in the inspector
    public float speed;
    
    //setting this to 100 in the inspector
    public float turnSpeed;

    public float horizontalInput;
    public float verticalInput;

    // Start is called before the first frame update
    void Update()
    {
      horizontalInput = Input.GetAxis("Horizontal");
      verticalInput = Input.GetAxis("Vertical");

        //move player with vertical input
      transform.Translate(Vector2.right * Time.deltaTime * speed * verticalInput);
      transform.Translate(Vector2.forward, turnSpeed * Time.deltaTime * horizontalInput);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
