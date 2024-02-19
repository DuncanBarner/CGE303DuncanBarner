using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerController : MonoBehaviour
{
  public float speed;
  public float turnSpeed;
  public float horizontalInput;
  public float verticalInput;


  void Update()
  {
    //Move forward
    //transform.Translate(1,0);

    //Which is the same as...
    //transform.Translate(Vector2.right);

    //Move forward 20meters/second if speed is set to 20
    //transform.Translate(Vector2.right * Time.deltaTime * speed);


    //Get Input - do this in Update()
    horizontalInput = Input.GetAxis("Horizontal");
    verticalInput = Input.GetAxis("Vertical");

    //Move player side-to-side with horizontal input
    //tranform.Translate(Vector2.right * turnSpeed * Time.deltaTime * horizontalInput);

    //Move player forward with vertical input
    transform.Translate(Vector2.right * Time.deltaTime * speed * verticalInput);

        //Rotate player with horizontal input
        if (verticalInput < 0)
        {
            transform.Rotate(Vector3.back, -turnSpeed * Time.deltaTime * horizontalInput);
        }
        else
        {
            transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);

        }
    }
}