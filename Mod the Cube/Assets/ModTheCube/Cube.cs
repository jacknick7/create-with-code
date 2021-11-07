using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * Random.Range(1.0f, 2.0f);
        
        Material material = Renderer.material;
        
        material.color = new Color(0.5f, 0.1f, 0.3f, Random.Range(0.2f, 1.0f));
    }
    
    void Update()
    {
        transform.Rotate(20.0f * Time.deltaTime, 5.0f * Time.deltaTime, 0.0f);
        transform.Translate(Vector3.forward * Time.deltaTime);
        transform.localScale += Vector3.one * 0.5f * Time.deltaTime;

        Material material = Renderer.material;
        float newG = material.color.g + 0.05f * Time.deltaTime;
        if (newG >= 1)
        {
            newG = 0;
        }
        material.color = new Color(material.color.r, newG, material.color.b, material.color.a);
    }
}
