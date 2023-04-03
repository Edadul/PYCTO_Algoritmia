using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public PolygonCollider2D ColliderI2D;
    public CapsuleCollider2D ColliderR2D;

    private Rigidbody2D Rb2D;
    private Animator Animator;

    private float Horizontal;
    private bool Grounded;

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
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            ColliderR2D.enabled = true;
            ColliderI2D.enabled = false;
        }
        else if (Horizontal > 0.0f) 
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            ColliderR2D.enabled = true;
            ColliderI2D.enabled = false;
        }
        else if (Horizontal == 0.0f)
        {
            ColliderR2D.enabled = false;
            ColliderI2D.enabled = true;
        }


        Animator.SetBool("Running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector2.down * 0.3f, Color.magenta);
        if(Physics2D.Raycast(transform.position, Vector2.down, 0.3f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
        }

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
