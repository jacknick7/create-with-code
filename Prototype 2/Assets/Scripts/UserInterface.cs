using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    private int lives = 3;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lives: " + lives + ", Score: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives()
    {
        lives -= 1;
        Debug.Log("Lives: " + lives);
        if (lives == 0)
        {
            Debug.Log("Game Over!");
        }
    }

    public void UpdateScore()
    {
        score += 1;
        Debug.Log("Score: " + score);
    }
}
