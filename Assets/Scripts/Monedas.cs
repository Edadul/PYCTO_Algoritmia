using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    [SerializeField] private GameObject efecto;
    [SerializeField] private float Cantidad;
    [SerializeField] private Puntaje points;
    [SerializeField] private Cant_rings ring;
    
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Jugador")){
            points.SumarScoore(Cantidad);
            ring.Rings();
            Destroy(gameObject);
        }
       


    }
    


}