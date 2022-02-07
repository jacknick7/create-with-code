using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameActive = false;

    private int score;
    private int shield;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        score = 0;
        //UpdateScore(0);
        shield = 100;
        //UpdateShield(0);
        isGameActive = true;
        // More here
    }

    public void QuitGame()
    {
        Debug.Log("Game quited!");
        Application.Quit();
    }
}
