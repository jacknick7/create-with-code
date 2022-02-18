using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBehaviour : MonoBehaviour
{
    public const int SHIELD_VALUE = 40;

    public float minSpeed = -1.0f;
    public float maxSpeed = -6.0f;

    public float minTorque = -1.0f;
    public float maxTorque = -6.0f;

    private Rigidbody powerupRb;

    // Start is called before the first frame update
    void Start()
    {
        powerupRb = GetComponent<Rigidbody>();
        float speed = Random.Range(minSpeed, maxSpeed);
        powerupRb.velocity = Vector3.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
