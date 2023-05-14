 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rb2D;
    private Vector2 Direccion;
     void Start()
    {

        Rb2D = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {

        Rb2D.velocity = Direccion * Speed;

    }
    public void SetDirection(Vector2 direccion)
    {

        Direccion = direccion;
    
    }
   
}
