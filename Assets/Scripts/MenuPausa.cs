using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject opc;
    [SerializeField] private GameObject cosasmenu;
   private bool detenido=false;
   private bool stop=false;
   public void Update(){
    if(Input.GetKeyDown(KeyCode.Escape)){
        if(detenido){
            RESUMEN();
            if(stop){
            volver();
            }
        }else{
            Paused();
            if(stop){
            opciones();
            }
        }    
   }
}
public void Paused(){
        detenido=true;
        Time.timeScale=0f;
        botonPausa.SetActive(false);
        menu.SetActive(true);
        cosasmenu.SetActive(false);
    }
    public void RESUMEN(){
        detenido=false;

        Time.timeScale=1f;
        botonPausa.SetActive(true);
        menu.SetActive(false);
        cosasmenu.SetActive(true);
    }
    public void Quit (){
        Application.Quit();
    }
    public void opciones(){
        stop=true;
        Time.timeScale=0f;
        menu.SetActive(false);
        opc.SetActive(true);
    }
    public void volver(){
        stop=false;
        Time.timeScale=0f;
        menu.SetActive(true);
        opc.SetActive(false);
    }
}
