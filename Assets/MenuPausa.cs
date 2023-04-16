using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject opc;
   private bool detenido=false;
   private bool stop=false;
   public void Update(){
    if(Input.GetKeyDown(KeyCode.Escape)){
        if(detenido){
            RESUMEN();
        }else{
            Paused();
        }
        if(stop){
            volver();
        }else{
        opciones();
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
    public void opciones(){
        detenido=true;
        Time.timeScale=0f;
        menu.SetActive(false);
        opc.SetActive(true);
    }
    public void volver(){
        detenido=false;
        Time.timeScale=0f;
        menu.SetActive(true);
        opc.SetActive(false);
    }
}
