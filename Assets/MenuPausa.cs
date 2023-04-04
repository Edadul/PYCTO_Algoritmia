using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menu;
   private bool detenido=false;
   public void Update(){
    if(Input.GetKeyDown(KeyCode.Escape)){
        if(detenido){
            RESUMEN();
        }else{
            Paused();
        }
    }
   }
    public void Paused(){
        detenido=true;
        Time.timeScale=0f;
        botonPausa.SetActive(false);
        menu.SetActive(true);
    }
    public void RESUMEN(){
        detenido=false;
        Time.timeScale=1f;
        botonPausa.SetActive(true);
        menu.SetActive(false);
    }
    public void Quit (){
        Application.Quit();
    }
}
