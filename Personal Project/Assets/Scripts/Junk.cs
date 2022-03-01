using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private int disintegrationScore;
    private int escapeScore;

    private float disintegrationDelayTime;
    private float escapeDelayTime;

    private GameManager gameManager;

    private AudioSource destroyAudioSource;
    [SerializeField] private AudioClip escapeAudioClip;
    private bool isSetToDestroy = false;

    // Start is called before the first frame update
    void Start()
    {
        escapeScore = -disintegrationScore / 2;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        destroyAudioSource = GetComponent<AudioSource>();
        destroyAudioSource.volume = gameManager.effectsVolume;
        disintegrationDelayTime = destroyAudioSource.clip.length;
        escapeDelayTime = escapeAudioClip.length;
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
            if (!isSetToDestroy) CollisionWithBullet();
        }
    }

    private void CollisionWithBullet()
    {
        health--;
        if (health == 0) Disintegration();
        // else
        // {
            // Here add desintegration effect shader (stronger effect as Junk has less health?)
        // }
    }

    private void Disintegration()
    {
        // Here add total desintegration effect and play score sound
        isSetToDestroy = true;
        gameManager.UpdateScore(disintegrationScore);
        destroyAudioSource.Play();
        Destroy(gameObject, disintegrationDelayTime);
    }

    public void Escape()
    {
        if (!isSetToDestroy)
        {
            isSetToDestroy = true;
            gameManager.UpdateScore(escapeScore);
            destroyAudioSource.clip = escapeAudioClip;
            destroyAudioSource.Play();
            Destroy(gameObject, escapeDelayTime);
        }
    }
}

