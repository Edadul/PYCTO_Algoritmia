using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Animations;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float Speed;
    public float Acceleration;
    public float JumpForce;
    public CircleCollider2D ColliderCir2D;
    public CapsuleCollider2D ColliderCap2D;
    private Rigidbody2D Rb2D;
    private Animator Animator;
    private float Horizontal;
    private float MaxSpeed = 7f;
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

        RunningSpeed();
        if (Horizontal == 0.0f)
        {
            Speed = 1f;
        }

        if (Horizontal > 0.0f)
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                StartCoroutine(WaitBeforeStopR());
            }
            else
            {
                transform.localScale = new Vector3(2.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
        }
        else if (Horizontal < 0.0f)
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                StartCoroutine(WaitBeforeStopL());
            }
            else
            {
                transform.localScale = new Vector3(-2.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }

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


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && Grounded == true)
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

        Animator.SetBool("Bolita", Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && Grounded == true);
        Animator.SetBool("Salto", Salto == true && Grounded == false);
        Animator.SetBool("Trans", Input.GetKey(KeyCode.LeftShift));
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

    private IEnumerator WaitTrans()
    {
        yield return new WaitForSeconds(1);
    }

    private IEnumerator WaitBeforeStopR()
    {
        yield return new WaitForSeconds(1f);
        transform.localScale = new Vector3(2.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }

    private IEnumerator WaitBeforeStopL()
    {
        yield return new WaitForSeconds(1f);
        transform.localScale = new Vector3(-2.5f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
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
