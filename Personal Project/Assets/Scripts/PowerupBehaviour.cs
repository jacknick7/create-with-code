using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    public int shieldValue = 40;

    public float minSpeed = 1.0f;
    public float maxSpeed = 6.0f;

    public float minTorque = 1.0f;
    public float maxTorque = 6.0f;

    private float xBound = 16.0f;
    private float yBound = 7.0f;

    private Rigidbody powerupRb;

    // Start is called before the first frame update
    void Start()
    {
        powerupRb = GetComponent<Rigidbody>();
        float speed = Random.Range(minSpeed, maxSpeed);
        powerupRb.velocity = Vector3.left * speed;
        float torque = Random.Range(minTorque, maxTorque);
        powerupRb.AddTorque(Vector3.up * torque, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xBound || transform.position.x > xBound || transform.position.y < -yBound || transform.position.y > yBound)
        {
            Destroy(gameObject);
        }
    }
}
