using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public CircleCollider2D ColliderCir2D;
    public CapsuleCollider2D ColliderCap2D;

    private Rigidbody2D Rb2D;
    private Animator Animator;

    private float Horizontal;
    private bool Grounded;
    private bool Salto;

    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Vector3 position = gameObject.transform.position;
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");

        if(Horizontal < 0.0f) 
        {
            transform.localScale = new Vector3(-2.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            //ColliderR2D.enabled = true;
            //ColliderI2D.enabled = false;
        }
        else if (Horizontal > 0.0f) 
        {
            transform.localScale = new Vector3(2.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            //ColliderR2D.enabled = true;
            //ColliderI2D.enabled = false;
        }
        else if (Horizontal == 0.0f)
        {
           //ColliderR2D.enabled = false;
           //ColliderI2D.enabled = true;
        }


        Animator.SetBool("Running", Horizontal != 0.0f);

        if(Physics2D.Raycast(transform.position, Vector2.down, 0.35f))
        {
            Grounded = true;
        }
        else 
        {
        Grounded = false;
        }
       

        if (Input.GetKeyDown(KeyCode.Space) && Grounded==true)
        {
            Jump();
            Salto = true;
        }
        if (Grounded)
        {
            ColliderCir2D.enabled = false;
            ColliderCap2D.enabled = true;
        }
        else
        {
            ColliderCir2D.enabled = true;
            ColliderCap2D.enabled = false;
        }

        Animator.SetBool("Salto", Salto == true && Grounded==false);
    }

    private void Jump()
    {
        Rb2D.AddForce(Vector2.up * JumpForce);
        

    }

    private void FixedUpdate()
    {
        Rb2D.velocity = new Vector2(Horizontal * Speed, Rb2D.velocity.y);
    }
}
