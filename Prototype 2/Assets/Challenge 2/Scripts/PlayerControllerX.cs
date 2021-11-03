using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float dogDelay = 0.5f;
    private float dogTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (dogTime > 0)
        {
            dogTime -= Time.deltaTime;
        }

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && dogTime <= 0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            dogTime = dogDelay;
        }
    }
}
