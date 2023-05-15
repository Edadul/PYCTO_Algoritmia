using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verde : MonoBehaviour
{
    [SerializeField] private GameObject es;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            es.SetActive(true);
        }
        else
        {
            es.SetActive(false);
        }
    }
}
