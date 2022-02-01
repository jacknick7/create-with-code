using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private variables
    // [SerializeField] float speed = 20.0f;
    [SerializeField] float horsePower = 0;
    [SerializeField] float turnSpeed = 60.0f;
    private float horizontalInput;
    private float forwardInput;
    public string horizontalAxisName;
    public string verticalAxisName;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get player input
        horizontalInput = Input.GetAxis(horizontalAxisName);
        forwardInput = Input.GetAxis(verticalAxisName);

        // Move the vehicle forward based on vertical input
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        // Turn the vehicle based on horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
