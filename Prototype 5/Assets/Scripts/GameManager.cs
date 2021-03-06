using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    private int score;
    private int lives;

    public bool isGameActive;

    public Button restartButton;
    public GameObject titleScreen;
    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive)
        {
            HandlePauseResume();
        }
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        if (lives > 0) UpdateLives(1);
        if (lives == 0)
        {
            restartButton.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(true);
            isGameActive = false;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        lives = 3;
        UpdateLives(0);
        StartCoroutine(SpawnTarget());
        titleScreen.gameObject.SetActive(false);
    }

    void UpdateLives(int livesToSub)
    {
        lives -= livesToSub;
        livesText.text = "Lives: " + lives;
    }

    void HandlePauseResume()
    {
        if (Time.timeScale == 0)
        {
            pauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
