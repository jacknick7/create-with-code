using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    private float horizontalBound = 30;

    private UserInterface userInterface;

    // Start is called before the first frame update
    void Start()
    {
        userInterface = GameObject.Find("/UserInterface").GetComponent<UserInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        // If an object goes past the players view in the game, remove that object
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            // Debug.Log("Game Over!");
            userInterface.UpdateLives();
            Destroy(gameObject);
        }
        else if (transform.position.x < -horizontalBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > horizontalBound)
        {
            Destroy(gameObject);
        }
    }
}
