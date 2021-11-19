using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15;
    public float dashSpeedMultiplier = 2;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            float speedMultiplier = 1;
            if (Input.GetKey(KeyCode.D))
            {
                speedMultiplier = dashSpeedMultiplier;
            }
            transform.Translate(Vector3.left * Time.deltaTime * speed * speedMultiplier);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
