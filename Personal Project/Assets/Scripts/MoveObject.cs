using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float horizontalSpeed = 5.0f;
    public float verticalSpeed = 5.0f;

    private float xBound = 16.0f;
    private float yBound = 7.0f;

    private Rigidbody objectRb;

    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        objectRb.velocity = new Vector3(horizontalSpeed, verticalSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xBound || transform.position.y < -yBound || transform.position.y > yBound)
        {
            Destroy(gameObject);
        }
    }

}
