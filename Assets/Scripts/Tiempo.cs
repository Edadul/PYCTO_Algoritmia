using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempo : MonoBehaviour
{
   private int mint,seconds,centes;
    private float timepas;
   
    // Update is called once per frame
    void Update()
    {
       
        timepas=Time.deltaTime;
        mint=(int(timepas*60f));
        seconds=(int(timepas-mint*60f));
        centes = (int(timepas - (int)timepas) * 100f);


    }
}
