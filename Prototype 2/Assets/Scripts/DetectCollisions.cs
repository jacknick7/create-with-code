using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private UserInterface userInterface;

    // Start is called before the first frame update
    void Start()
    {
        userInterface = GameObject.Find("/UserInterface").GetComponent<UserInterface>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            // Debug.Log("Game Over!");
            userInterface.UpdateLives();
        }
        else
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            userInterface.UpdateScore();
        }
    }
}
