using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    //Create a variable to track whether the trigger zone is active
    bool active = true;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if trigger zone is active
        if (active && collision.gameObject.tag == "Player")
        {
            //deactivate trigger zone

            active = false;
            //Adds one to score when player enters trigger zone
            ScoreManager.score++;
            gameObject.SetActive(false);
        }
    }
}
