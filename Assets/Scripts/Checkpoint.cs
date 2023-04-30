using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Animator ani;
    private void OnTrigger2D(Collider2D collision){
        if(collision.CompareTag("Jugador")){
           Debug.Log("Paso");
            collision.GetComponent<Player_respawn>().pasarcheckpoint(transform.position.x,transform.position.y);
            ani.Play("CheckPoint");
        }
    }
}
