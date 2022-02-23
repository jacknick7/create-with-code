using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkBehaviour : MonoBehaviour
{
    [SerializeField] private int hitValue;
    [SerializeField] private int scoreValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Junk"))
        {
            // Here make THIS Junk bounce in opposite directions
            Debug.Log("Junk collieded with Junk");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("IMPACT");
    }
}
