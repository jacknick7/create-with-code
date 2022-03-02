using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = false;

    private int score;
    private int shield;
    private const int MAX_SHIELD = 150;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI shieldText;
    [SerializeField] private GameObject uIScreen;

    private bool isGamePaused = false;
    [SerializeField] private GameObject pauseScreen;

    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private PlayerController playerController;

    public float effectsVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive)
        {
            PauseResumeGame();
        }
    }

    public void StartGame()
    {
        score = 0;
        UpdateScore(0);
        shield = 100;
        UpdateShield(0);
        uIScreen.SetActive(true);
        playerController.ResetPlayer();
        isGameActive = true;
        // More here
    }

    public void PauseResumeGame()
    {
        if (isGamePaused)
        {
            pauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        isGamePaused = !isGamePaused;
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        // Here change player to explosion + destroy delayed

        isGameActive = false;

        uIScreen.SetActive(false);
        finalScoreText.SetText("FINAL SCORE: " + score + "pts");
        gameOverScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Game quited!");
        Application.Quit();
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.SetText("SCORE: " + score);
    }

    public void UpdateShield(int shieldToAdd)
    {
        shield = Mathf.Min(shield + shieldToAdd, MAX_SHIELD);
        shieldText.SetText("SHIELD: " + shield + '%');
        if (shield < 0)
        {
            shieldText.SetText("SHIELD: --");
            GameOver();
        }
    }

    public void SetEffectsVolume(float newEffectsVolume)
    {
        effectsVolume = newEffectsVolume;
    }
}
