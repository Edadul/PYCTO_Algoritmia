using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cangrejo : MonoBehaviour
{
    [SerializeField] private float VelocityMov;
    [SerializeField] private LayerMask evitar;
    [SerializeField] private float Distancia;
    private float x, y, z;
    private Rigidbody2D rb2D;
    public GameObject Sonic;

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
        if (dis < 2.0f)
        {
            Vector3 direccion = Sonic.transform.position - transform.position;
            if (direccion.x >= 0.0f) transform.localScale = new Vector3(x, y,z);
            else transform.localScale = new Vector3(-x, y, z);
            atack();

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

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Sonic.transform.position.x, transform.position.y), VelocityMov * Time.deltaTime);

    }
    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * Distancia);

    }
}
