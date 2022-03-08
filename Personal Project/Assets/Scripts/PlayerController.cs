using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 7.0f;
    [SerializeField] private float maxSpeed = 4.0f;

    [SerializeField] private GameObject outOfBoundsText;
    private float outOfBoundsTimer = 0.0f;
    private const float OUTOFBOUNDS_TIME = 2.0f;
    private float yBound = 5.25f;
    private float xBound = 14.15f;

    private Rigidbody playerRb;

    private float bulletTimer = 0.0f;
    private const float BULLET_TIME = 0.5f;
    private Vector3 bulletOffset = new Vector3(0.5f, 0, 0.4f);

    private Vector3 iniPos;

    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject explosion;

    private GameManager gameManager;
    private SpawnManager spawnManager;

    // Start is called before the first frame update
    private void Start()
    {
        iniPos = transform.position;
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        HandleShooting();

        if (outOfBoundsTimer > 0)
        {
            outOfBoundsTimer -= Time.deltaTime;
            if (outOfBoundsTimer <= 0)
            {
                outOfBoundsText.gameObject.SetActive(false);
            }
        }
        if (bulletTimer > 0)
        {
            bulletTimer -= Time.deltaTime;
        }
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

    // Prevent the player from leaving screen space, velocity component affected is reset to zero
    // so the player can return to the screen quickly. Also show UI text for some time.
    void ConstrainPlayerPosition()
    {
        bool isOutOfBound = false;
        Vector3 newPos = transform.position;
        Vector3 newVel = playerRb.velocity;

        if (transform.position.y < -yBound)
        {
            newPos.y = -yBound;
            newVel.y = 0;
            isOutOfBound = true;
        }
        else if (transform.position.y > yBound)
        {
            newPos.y = yBound;
            newVel.y = 0;
            isOutOfBound = true;
        }

        if (transform.position.x < -xBound)
        {
            newPos.x = -xBound;
            newVel.x = 0;
            isOutOfBound = true;
        }
        else if (transform.position.x > xBound)
        {
            newPos.x = xBound;
            newVel.x = 0;
            isOutOfBound = true;
        }

        if (isOutOfBound)
        {
            transform.position = newPos;
            playerRb.velocity = newVel;
            outOfBoundsText.gameObject.SetActive(true);
            outOfBoundsTimer = OUTOFBOUNDS_TIME;
        }
    }

    // Shoots a bullet based on space input and a cooldown
    void HandleShooting()
    {
        if (Input.GetKey(KeyCode.Space) && bulletTimer <= 0)
        {
            Debug.Log("Shoot!");
            spawnManager.SpawnBullet(transform.position + bulletOffset);
            bulletTimer = BULLET_TIME;
        }
    }

    // TODO: give some seconds of invencibility after collision with junk
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Junk"))
        {
            // Here decrease player shields, player can choose to sacrifice shields to destroy junk, score is also increased this way
            // Each Junk will have it's own damage value
            gameManager.UpdateShield(-30);
            Debug.Log("Player collided with some Junk");
            Destroy(collision.gameObject);
        }
    }

    public void ResetPlayer()
    {
        transform.position = iniPos;
        playerRb.velocity = Vector3.zero;
        shield.SetActive(false);
        explosion.SetActive(false);
        bulletTimer = 0;
        outOfBoundsTimer = 0;
        outOfBoundsText.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}
