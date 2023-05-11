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
    public bool canmove = true;
    [SerializeField] private Vector2 Velrebote;
    [SerializeField] private float tiempoControl;
    public AudioClip sonido;

    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Vector3 position = gameObject.transform.position;
    }

    void Update()
    {
        if (canmove)
        {
            Horizontal = Input.GetAxis("Horizontal");
        }

        StartCoroutine(SpeedSeconds());
        if (Horizontal == 0.0f)
        {
            Speed = 1.0f;
        }


        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-2.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(2.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }


        Animator.SetBool("Running", Horizontal != 0.0f);

        if (Physics2D.Raycast(transform.position, Vector2.down, 0.35f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) && Grounded == true)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
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

        Animator.SetBool("Salto", Salto == true && Grounded == false);
    }

    private void Jump()
    {
        Rb2D.AddForce(Vector2.up * JumpForce);
    }

    private IEnumerator SpeedSeconds()
    {
        if(Horizontal != 0.0f)
        {
            yield return new WaitForSeconds(0.5f);
            Speed = 3f;
            Animator.SetFloat("Speed", Speed);

            yield return new WaitForSeconds(1.5f);
            Speed = 4f;
            Animator.SetFloat("Speed", Speed);

            yield return new WaitForSeconds(2.5f);
            Speed = 6f;
            Animator.SetFloat("Speed", Speed);
        }
    }
    public void rebote(Vector2 golpe)
    {
        Rb2D.velocity= new Vector2(-Velrebote.x*golpe.x,Velrebote.y);
    }
        public void tomarDaño(Vector2 pos)
    {
        StartCoroutine(percontrol());
        rebote(pos);
    }
    private IEnumerator percontrol()
    {
        canmove=false;
        yield return new WaitForSeconds(tiempoControl);
        canmove=true;
    }

    private void FixedUpdate()
    {
        Rb2D.velocity = new Vector2(Horizontal * Speed, Rb2D.velocity.y);
    }
}
