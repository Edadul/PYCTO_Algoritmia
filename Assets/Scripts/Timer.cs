using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
   public int mint,seconds,centes;
    public float timepas,time;
    [SerializeField] private TMP_Text timer;
    [SerializeField] private GameObject over;
    [SerializeField] private GameObject other;
    // Update is called once per frame
    void Update()
    {
       
        timepas+=Time.deltaTime;
        time = timepas;
        mint=(int)(timepas/60f);
        seconds=(int)(timepas-mint*60f);
        centes = (int)((timepas-(int)timepas)*1000f);

        timer.text = string.Format("{0:00}:{1:00}:{2:00}", mint, seconds, centes);
        if(mint>=2)
        {

            Time.timeScale = 0f;
            over.SetActive(true);
            other.SetActive(false);

        }
        else
        {

            Time.timeScale = 1f;
            over.SetActive(false);
            other.SetActive(true);

        }
    }

   
}
