using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] junk;
    public GameObject powerup;

    private float xSpawn = 15.0f;
    private float ySpawnRange = 4.5f;

    private float startDelay = 1.0f;
    private float junkSpawnTime = 1.5f;
    private float powerupSpawnTime = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomJunk", startDelay, junkSpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomJunk()
    {
        int randomIndex = Random.Range(0, junk.Length);

        float ySpawn = Random.Range(-ySpawnRange, ySpawnRange);
        Vector3 spawnPos = new Vector3(xSpawn, ySpawn, junk[randomIndex].gameObject.transform.position.z);

        Instantiate(junk[randomIndex], spawnPos, junk[randomIndex].gameObject.transform.rotation);
        // Change speed values for new instantiate junk here
    }

    void SpawnPowerup()
    {
        float ySpawn = Random.Range(-ySpawnRange, ySpawnRange);
        Vector3 spawnPos = new Vector3(xSpawn, ySpawn, powerup.gameObject.transform.position.z);

        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
        // Change speed values for new instantiate powerup here
    }
}
