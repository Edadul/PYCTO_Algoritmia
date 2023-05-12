using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
   private int mint,seconds,centes;
    private float timepas;
    [SerializeField] private TMP_Text timer;
    // Update is called once per frame
    void Update()
    {
       
        timepas+=Time.deltaTime;
        mint=(int)(timepas/60f);
        seconds=(int)(timepas-mint*60f);
        centes = (int)((timepas-(int)timepas)*1000f);

        timer.text = string.Format("{0:00}:{1:00}:{2:00}", mint, seconds, centes);
    }

   
}
