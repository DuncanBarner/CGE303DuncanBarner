using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnFall : MonoBehaviour
{
    //set this in the inspector
    public float lowestY;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //If player is lower than the lowest y boundary, the player loses (falls off platforms)
        if(transform.position.y < lowestY)
        {
            //trigger player loss/make player lose
            ScoreManager.gameOver = true;

        }

        
    }
}
