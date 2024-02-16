using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    //Notice public static variables can be accessed from any script
    //but cannot be seen in the inspector
    public static bool gameOver;
    public static bool won;
    public static int score;
    
    // Start is called before the first frame update

    //set this in inspector
    public TMP_Text textbox;
    public int scoreToWin;
    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            textbox.text = "Score: " + score;
        }
        if (score >= scoreToWin)
        {
            won = true;
            gameOver = true;
        }
        if (gameOver)
        {
            if (won)
            {
                textbox.text = "You win!\n Press R to Play Again!";
            }
            else
            {
                textbox.text = "You Lose! \n Press R to Try Again!";
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
