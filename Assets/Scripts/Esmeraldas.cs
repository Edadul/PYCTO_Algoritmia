using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class Esmeraldas : MonoBehaviour
{
    public AudioClip sonido;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
            Destroy(gameObject);
        }
    }
}
