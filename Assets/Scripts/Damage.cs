using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
     private void OnCollisionEnter2D(Collision2D collision)
   {
    collision.transform.GetComponent<Player_respawn>().PlayerDamaged();
   }
}
