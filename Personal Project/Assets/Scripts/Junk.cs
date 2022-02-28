using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private int disintegrationScore;
    private int escapeScore;

    private GameManager gameManager;

    private AudioSource destroyAudioSource;
    [SerializeField] private AudioClip escapeAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        escapeScore = -disintegrationScore / 2;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        destroyAudioSource = GetComponent<AudioSource>();
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
            CollisionWithBullet();
        }
    }

    private void CollisionWithBullet()
    {
        health--;
        if (health == 0)
        {
            Disintegration();
        }
        // else
        // {
            // Here add desintegration effect shader (stronger effect as Junk has less health?)
        // }
    }

    private void Disintegration()
    {
        // Here add total desintegration effect and play score sound
        gameManager.UpdateScore(disintegrationScore);
        destroyAudioSource.Play();
        Destroy(gameObject, 0.2f);
    }

    public void Escape()
    {
        gameManager.UpdateScore(escapeScore);
        destroyAudioSource.clip = escapeAudioClip;
        destroyAudioSource.Play();
        Destroy(gameObject, 0.5f);
    }
}

