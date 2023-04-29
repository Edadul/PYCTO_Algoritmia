using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
    
{
    // Start is called before the first frame update
    public Vector2 cameraVelocidad;
    private Vector2 offset;
    private Material material;
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = cameraVelocidad * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
