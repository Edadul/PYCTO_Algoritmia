using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_sonic : MonoBehaviour
{
     public float Speed;
    public float JumpForce;
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
         if(Horizontal < 0.0f) 
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        }else if(Horizontal>0.0f){
             transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        Animator.SetBool("Running", Horizontal != 0.0f);
        Debug.DrawRay(transform.position, Vector2.down*0.3f, Color.red);
        if(Physics2D.Raycast(transform.position, Vector2.down, 0.3f))
        {
            Grounded = true;
        }else {
        Grounded = false;
        }
           if (Input.GetKeyDown(KeyCode.Space) && Grounded==true)
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
