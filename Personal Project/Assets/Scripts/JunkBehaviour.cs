using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBehaviour : MonoBehaviour
{
    [SerializeField] private int hitValue;
    [SerializeField] private int scoreValue;

    public float minSpeed = 1.0f;
    public float maxSpeed = 6.0f;

    public float minTorque = 1.0f;
    public float maxTorque = 6.0f;

    private float xBound = 16.0f;
    private float yBound = 7.0f;

    private Rigidbody junkRb;

    // Start is called before the first frame update
    void Start()
    {
        junkRb = GetComponent<Rigidbody>();
        float speed = Random.Range(minSpeed, maxSpeed);
        Vector3 dir = new Vector3(-xBound, Random.Range(-yBound, yBound), 0) - transform.position;
        junkRb.velocity = dir.normalized * speed;
        float torque = Random.Range(minTorque, maxTorque);
        junkRb.AddTorque(new Vector3(1, 1, 0) * torque, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xBound || transform.position.x > xBound || transform.position.y < -yBound || transform.position.y > yBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Junk"))
        {
            // Here make THIS Junk bounce in opposite directions
            Debug.Log("Junk collieded with Junk");
        }
    }
}
