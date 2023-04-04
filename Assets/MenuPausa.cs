using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menu;
    public void Paused(){
        Time.timeScale=0f;
        botonPausa.SetActive(false);
        menu.SetActive(true);
    }
    public void RESUMEN(){
        Time.timeScale=1f;
        botonPausa.SetActive(true);
        menu.SetActive(false);
    }
    public void Quit (){

    }
}
