using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoParalax : MonoBehaviour
{
    [SerializeField] private Vector2 Velmov;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D JB;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        JB = GameObject.FindGameObjectWithTag("Jugador").GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        offset = (JB.velocity.x *0.1f) *Velmov* Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
