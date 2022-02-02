using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Private variables
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] float horsePower = 0;
    [SerializeField] float turnSpeed = 60.0f;
    private float horizontalInput;
    private float forwardInput;
    public string horizontalAxisName;
    public string verticalAxisName;
    private Rigidbody playerRb;

    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get player input
        horizontalInput = Input.GetAxis(horizontalAxisName);
        forwardInput = Input.GetAxis(verticalAxisName);

        if (IsOnGround())
        {
            // Move the vehicle forward based on vertical input
            // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            // Turn the vehicle based on horizontal input
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            // calculate and print speed
            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f); // 2.237 for mph
            speedometerText.SetText("Speed: " + speed + " kph");

            // calculate and print rpm
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
