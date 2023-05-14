using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.transform.CompareTag("Jugador")  )
        {
           
            Destroy(gameObject);

        }
        else
        {

            if(coll.transform.CompareTag("Ground"))
            {

                Destroy(gameObject);

            }

        }

    }
}
