using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efectosonido : MonoBehaviour
{

    [SerializeField] private AudioClip colectar1;

    private void OnTriggerEnter2d(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            controladorconidos.Monedas.EjecutarSonido(AudioClip);
            Destroy(gameObject);
        }

    }
}
 