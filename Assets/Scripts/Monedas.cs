using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
    [SerializeField] private GameObject efecto;
    [SerializeField] private float Cantidad;
    [SerializeField] private Puntaje points;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Jugador")){
            points.SumarScoore(Cantidad);
            Instantiate(efecto,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
