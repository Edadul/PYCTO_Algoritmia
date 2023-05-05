using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private Cant_vidas aux1;
    [SerializeField] private Cant_rings compr;
     public Animator anim;
    private float au;
    private float vid;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        compr.comp_rings(au);
        

        if (collision.transform.CompareTag("Jugador"))
        {
            if(au!=0)
            {
                anim.Play("Hit");
                compr.zeroring();
            }else{
                
               aux1.quitarvidas();
            }
        }

    }
}
