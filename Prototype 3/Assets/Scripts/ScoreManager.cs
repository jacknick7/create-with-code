using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private PlayerController playerControllerScript; 
    
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("IncreaseScore", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncreaseScore()
    {
        if (!playerControllerScript.gameOver)
        {
            score += 1;
            if (Input.GetKey(KeyCode.D))
            {
                score += 1;
            }
            Debug.Log("Score: " + score + " pts.");
        }
    }
}
