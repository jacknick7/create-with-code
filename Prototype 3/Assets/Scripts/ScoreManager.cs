using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private PlayerController playerControllerScript;

    public Transform startingPoint;
    public float lerpSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("IncreaseScore", 0, 1);

        playerControllerScript.gameOver = true;
        StartCoroutine(PlayIntro());
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

    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerControllerScript.transform.position;
        Vector3 endPos = startingPoint.position;
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;

        playerControllerScript.GetComponent<Animator>().speed = 0.5f;

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }

        playerControllerScript.GetComponent<Animator>().speed = 1.5f;
        playerControllerScript.gameOver = false;
    }
}
