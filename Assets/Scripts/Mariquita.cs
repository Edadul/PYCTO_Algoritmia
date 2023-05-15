using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Mariquita : MonoBehaviour
{
    [SerializeField] private float VelocityMov;
    [SerializeField] private LayerMask evitar;
    [SerializeField] private float Distancia;
    private Rigidbody2D rb2D;
    public GameObject Sonic;
    private bool girar=true;
    
   void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();   
    }
    void Update()
    {
        if(girar)
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
            if (direccion.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            atack();

        }
        else
        {

            girar = true;
             transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);          

        }
    }
    private void Girar()
    {

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

    }

    private void atack()
    {

        girar = false;
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
            if(collision.transform.GetComponent<Player_Movement>().Transformed == true || collision.transform.GetComponent<Player_Movement>().Attack == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
