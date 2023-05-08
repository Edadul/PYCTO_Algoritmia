using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private Cant_vidas aux1;
    [SerializeField] private Cant_rings comp;

    public Animator anim;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Jugador"))
        {
            if (comp.cant > 0 && comp.sw==1)
            {
                collision.gameObject.GetComponent<Player_Movement>().tomarDaño(collision.GetContact(0).normal);
                anim.SetTrigger("Hit");
                comp.zeroring();
            }

            if (comp.cant == 0 && comp.sw==0) 
            {
                collision.gameObject.GetComponent<Player_Movement>().tomarDaño(collision.GetContact(0).normal);
                aux1.quitarvidas();
            }


        }

    }
}
