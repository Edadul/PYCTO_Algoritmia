using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private Cant_vidas aux1;
    [SerializeField] private Cant_rings comp;

    public Animator anim;
    

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Jugador"))
        {
            if (comp.cant > 0  )
            {
                collision.gameObject.GetComponent<Player_Movement>().tomarDaño(collision.GetContact(0).normal);
                comp.zeroring();
            }else {
                if (comp.cant == 0)
                {
                    collision.gameObject.GetComponent<Player_Movement>().tomarDaño(collision.GetContact(0).normal);
                    aux1.quitarvidas();
                }
            }
            

        }

    }
}
