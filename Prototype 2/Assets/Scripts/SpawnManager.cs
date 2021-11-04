using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    private float spawnHoriRangeZMin = 2;
    private float spawnHoriRangeZMax = 14;
    private float spawnHoriPosX = 25;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalHorizontal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        // Randomly generate animal index and spawn position
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalHorizontal()
    {
        // Randomly generate animal index and spawn position
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos;
        Quaternion spawnRot;
        int direction = Random.Range(0, 2);
        if (direction == 0)
        {
            spawnPos = new Vector3(-spawnHoriPosX, 0, Random.Range(spawnHoriRangeZMin, spawnHoriRangeZMax));
            spawnRot = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            spawnPos = new Vector3(spawnHoriPosX, 0, Random.Range(spawnHoriRangeZMin, spawnHoriRangeZMax));
            spawnRot = Quaternion.Euler(0, -90, 0);
        }
        GameObject aux = Instantiate(animalPrefabs[animalIndex], spawnPos, spawnRot);
    }
}
