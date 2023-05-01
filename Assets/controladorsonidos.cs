using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorsonidos : MonoBehaviour
{
    private static controladorsonidos Monedas;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Monedas == null)
        {
            Monedas = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void EjecutarSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }
}
