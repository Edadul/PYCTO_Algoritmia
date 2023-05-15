using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanarLevel : MonoBehaviour
{
    [SerializeField] private GameObject pass;
    [SerializeField] private GameObject other;
    public void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Bandera"))
        {
            Time.timeScale = 0f;
            pass.SetActive(true);
            other.SetActive(false);
        }
        else
        {
            Time.timeScale = 1f;
            pass.SetActive(false);
            other.SetActive(true);
        }
    }
}
