using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private int score;

    // Assing this in start + add score when necesary
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Hit();
        }
    }

    private void Hit()
    {
        health--;
        // Here add desintegration effect shader (stronger effect as Junk has less health?)
        if (health == 0)
        {
            // Here add total desintegration effect and play score sound and add Junk score to current score
            Destroy(gameObject, 0.2f);
        }
    }
}
