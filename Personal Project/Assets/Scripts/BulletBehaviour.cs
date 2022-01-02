using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
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
        if (other.gameObject.CompareTag("Junk"))
        {
            // Here add desintegration effect to other and a deley to the destroy
            Destroy(other.gameObject, 0.2f);
            Destroy(gameObject);
        }
    }
}
