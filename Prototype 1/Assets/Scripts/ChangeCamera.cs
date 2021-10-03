using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject outsideCamera, insideCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (outsideCamera.activeSelf)
            {
                outsideCamera.SetActive(false);
                insideCamera.SetActive(true);
            }
            else
            {
                outsideCamera.SetActive(true);
                insideCamera.SetActive(false);
            }
        }
    }
}
