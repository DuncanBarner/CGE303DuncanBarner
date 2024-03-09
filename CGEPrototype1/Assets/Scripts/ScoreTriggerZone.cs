using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    //Create a variable to track whether the trigger zone is active
    bool active = true;
    public AudioClip pickupSound;
    private AudioSource audioSource;


    // Start is called before the first frame update
    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if an AudioSource component exists, if not, add one


        // Assign the pickup sound to the AudioSource
        audioSource.clip = pickupSound;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if trigger zone is active
        if (active && collision.gameObject.tag == "Player")
        {

            audioSource.PlayOneShot(pickupSound);
            //deactivate trigger zone

            active = false;
            //Adds one to score when player enters trigger zone
            ScoreManager.score++;



            StartCoroutine(DeactivateWithDelay()); //creating this to allow pickup sound to play
            //gameObject.SetActive(false); commented out because it doesn't allow pickup sound to play 
        }
    }
    private IEnumerator DeactivateWithDelay()
    {
        // Wait for the duration of the pickup sound
        yield return new WaitForSeconds(audioSource.clip.length);

        // Deactivate the trigger zone GameObject
        gameObject.SetActive(false);
    }
}
