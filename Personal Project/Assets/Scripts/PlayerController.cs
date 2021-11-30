using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 1.0f;
    private float yBound = 5.25f;
    private float xBound = 14.15f;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
        HandleShooting();
    }

    // Move the player based on WASD/arrows keys input
    // TODO: -explore how to aboid current acceleration, maybe use another movement system?
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.up * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    // Prevent the player from leaving screen space, velocity is reset to zero so the player can return to the screen quickly
    // TODO: -add UI text in the screen center each time the player touches a bound
    void ConstrainPlayerPosition()
    {
        if (transform.position.y < -yBound)
        {
            transform.position = new Vector3(transform.position.x, -yBound, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }
        else if (transform.position.y > yBound)
        {
            transform.position = new Vector3(transform.position.x, yBound, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }
        else if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            playerRb.velocity = Vector3.zero;
        }
    }

    // Shoots a bullet based on space input and a cooldown
    // TODO: -add the cooldown
    void HandleShooting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Shoot!");
        }
    }
}
