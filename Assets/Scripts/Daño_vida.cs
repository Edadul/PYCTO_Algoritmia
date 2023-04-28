using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño_vida : MonoBehaviour
{
     private void OnCollisionEnter2D(Collision2D collision)
   {
    if(collision.transform.CompareTag("Jugador"))
    {
       
        Destroy(collision.gameObject);
    }
   }
}
