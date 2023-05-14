using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Speed;
    public float Acceleration;
    public CircleCollider2D ColliderCir2D;
    public CapsuleCollider2D ColliderCap2D;
    private Rigidbody2D Rb2D;
    private Animator Animator;
    private float Horizontal;
    private float JumpForce = 500f;
    private float MaxSpeed = 7f;
    private bool Grounded;
    private bool Salto;
    public bool canmove = true;
    [SerializeField] private Vector2 Velrebote;
    [SerializeField] private float tiempoControl;
    public AudioClip sonido;
    [SerializeField] private Cant_vidas aux1;
    [SerializeField] private Cant_rings comp;

    public Animator anim;
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
            JumpForce = 500f;
        }
        else
        {
            JumpForce = 0f;
            Horizontal = 0f;
        }

        if (Horizontal != 0)
        {
            RunningSpeed();
        }
        else if (Horizontal == 0.0f)
        {
            Speed = 1.0f;
        }

        if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(2.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        else if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-2.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }

        Animator.SetBool("Running", Horizontal != 0.0f);

        Debug.DrawRay(Rb2D.transform.position, Rb2D.transform.up * -0.4f, UnityEngine.Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.4f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && Grounded == true)
        {
            Jump();
            Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
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

        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && Grounded)
        {
            Animator.SetTrigger("Bolita");
            StartCoroutine(BolitaToRun());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Animator.SetTrigger("Trans Anim");
            canmove = false;
            StartCoroutine(Transformation());
        }
        else
        {
            Animator.ResetTrigger("Trans Anim");
            Animator.SetBool("TtN", false);
        }
        
        Animator.SetBool("Salto", Salto == true && Grounded == false);
    }

    private void Jump()
    {
        Rb2D.AddForce(Vector2.up * JumpForce);
    }

    private void RunningSpeed()
    {
        Animator.SetFloat("Speed", Speed);
        Speed += Acceleration * Time.deltaTime;
        if (Speed > MaxSpeed)
        {
            Speed = MaxSpeed;
        }
    }

    private IEnumerator BolitaToRun()
    {
        yield return new WaitForSeconds(2);
        Animator.ResetTrigger("Bolita");
        Animator.SetBool("BtR", true);
        yield return new WaitForSeconds(1);
        Animator.SetBool("BtR", false);
    }
    private IEnumerator Transformation()
    { 
        yield return new WaitForSeconds(1f);
        canmove = true;
        Animator.SetBool("Trans", true);
        yield return new WaitForSeconds(3f);
        Animator.SetBool("Trans", false);
        canmove = false;
        yield return new WaitForSeconds(1.1f);
        Animator.SetBool("TtN", true);
        canmove = true;
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
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("bala"))
        {
            if (comp.cant > 0)
            {
               
    
                comp.zeroring();
            }
            else
            {
                if (comp.cant == 0)
                {
                   
                    aux1.quitarvidas();
                }
            }


        }
    }
}
