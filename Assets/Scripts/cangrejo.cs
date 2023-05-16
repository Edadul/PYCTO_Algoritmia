using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class cangrejo : MonoBehaviour
{
    [SerializeField] private float VelocityMov;
    [SerializeField] private LayerMask evitar;
    [SerializeField] private float Distancia;
    private float X, Y, Z;
    public GameObject Bala_cangreloprefab;
    private Rigidbody2D rb2D;
    public GameObject Sonic;
    public float balapas;
    public bool girar = true;
    public AudioClip vencido2;

    void Start()
    {
       
        rb2D = GetComponent<Rigidbody2D>();
        X = transform.localScale.x;
        Y = transform.localScale.y;
        Z = transform.localScale.z;
    
    }
    
    void Update()
    {
        if (girar)
        {
            rb2D.velocity = new Vector2(VelocityMov * transform.right.x, rb2D.velocity.y);
            RaycastHit2D informacion = Physics2D.Raycast(transform.position, transform.right, Distancia, evitar);
            if (informacion)
            {
                Girar();
            }
        }
       

        float dis = Mathf.Abs(Sonic.transform.position.x - transform.position.x);
        if (dis < 2.0f )
        {
            Vector3 direccion = Sonic.transform.position - transform.position;
            if (direccion.x >= 0.0f) transform.localScale = new Vector3(X, Y,Z);
            else transform.localScale = new Vector3(-X, Y, Z);
            if(Time.time > balapas + 0.40f)
            {
                atack();
                balapas = Time.time;
            }
            

        }
        else
        {

            girar = true;
            transform.localScale = new Vector3(X, Y, Z);

        }
    }
    private void Girar()
    {

        girar = false;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

    }

    private void atack()
    {

        Vector3 direccion;
        if (transform.localScale.x == X) direccion = Vector3.right;
        else direccion = Vector3.left;
        GameObject Bala_cangrelo = Instantiate(Bala_cangreloprefab, transform.position + direccion * 0.1f, Quaternion.identity);
        Bala_cangrelo.GetComponent<Bala>().SetDirection(direccion);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Sonic.transform.position.x, transform.position.y), VelocityMov * Time.deltaTime);

    }
    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * Distancia);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Jugador"))
        {
            if (collision.transform.GetComponent<Player_Movement>().Transformed == true || collision.transform.GetComponent<Player_Movement>().Attack == true)
            {
                Camera.main.GetComponent<AudioSource>().PlayOneShot(vencido2);
                Destroy(gameObject);
            }
        }
    }
}
