using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 7.0f;
    [SerializeField] private float maxSpeed = 4.0f;
    private float yBound = 5.25f;
    private float xBound = 14.15f;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleShooting();
    }

    // FixedUpdate is used when applying physics-related functions
    private void FixedUpdate()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    // Move the player with forces based on WASD or arrows keys input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.up * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

        // Limit our velocity to maxSpeed
        if (playerRb.velocity.magnitude > maxSpeed)
        {
            playerRb.velocity = playerRb.velocity.normalized * maxSpeed;
        }
    }

    // Prevent the player from leaving screen space, velocity component affected is reset to zero so the player can return to the screen quickly
    // TODO: -add UI text in the screen center each time the player touches a bound
    void ConstrainPlayerPosition()
    {
        if (transform.position.y < -yBound)
        {
            transform.position = new Vector3(transform.position.x, -yBound, transform.position.z);
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0, 0);
        }
        else if (transform.position.y > yBound)
        {
            transform.position = new Vector3(transform.position.x, yBound, transform.position.z);
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0, 0);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            playerRb.velocity = new Vector3(0, playerRb.velocity.y, 0);
        }
        else if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
            playerRb.velocity = new Vector3(0, playerRb.velocity.y, 0);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            // Here apply whatever powerup does
            Debug.Log("Player has Powerup");
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Junk"))
        {
            // Here decrease player shields, player can choose to sacrifice shields to destroy junk, score is also increased this way
            Debug.Log("Player collided with some Junk");
            Destroy(collision.gameObject);
        }
    }
}
