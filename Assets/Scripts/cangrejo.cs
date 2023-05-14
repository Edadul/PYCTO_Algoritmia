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
    private float x, y, z;
    public GameObject Bala_cangreloprefab;
    private Rigidbody2D rb2D;
    public GameObject Sonic;
    public float balapas;

    void Start()
    {
       
        rb2D = GetComponent<Rigidbody2D>();
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;
    
    }
    
    void Update()
    {
        rb2D.velocity = new Vector2(VelocityMov * transform.right.x, rb2D.velocity.y);
        RaycastHit2D informacion = Physics2D.Raycast(transform.position, transform.right, Distancia, evitar);
        if (informacion)
        {
            Girar();
        }

        float dis = Mathf.Abs(Sonic.transform.position.x - transform.position.x);
        if (dis < 2.0f && Time.time > balapas+0.40f)
        {
            Vector3 direccion = Sonic.transform.position - transform.position;
            if (direccion.x >= 0.0f) transform.localScale = new Vector3(x, y,z);
            else transform.localScale = new Vector3(-x, y, z);
            atack();
            balapas=Time.time;

        }
        else
        {

            transform.localScale = new Vector3(x, y, z);

        }
    }
    private void Girar()
    {

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);

    }

    private void atack()
    {

        Vector3 direccion;
        if (transform.localScale.x == x) direccion = Vector3.right;
        else direccion = Vector3.left;
        GameObject Bala_cangrelo = Instantiate(Bala_cangreloprefab, transform.position + direccion * 0.1f, Quaternion.identity);
        Bala_cangrelo.GetComponent<Bala>().SetDirection(direccion);
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(Sonic.transform.position.x, transform.position.y), VelocityMov * Time.deltaTime);

    }
    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * Distancia);

    }
}
