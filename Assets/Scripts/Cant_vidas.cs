using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cant_vidas : MonoBehaviour
{
   [SerializeField] private Player_respawn res;
   [SerializeField] private Cant_rings compr;
    public float lifes=3; 
   private TextMeshProUGUI textMesh;
    [SerializeField] private GameObject Over;
    [SerializeField] private GameObject other;
    private void Start()
    {
        textMesh= GetComponent<TextMeshProUGUI>();
      

    }
    private void Update()
    {
       
        textMesh.text=lifes.ToString();
        if (lifes < 1)
        {

            res.PlayerDamaged();
            Time.timeScale = 0f;
            Over.SetActive(true);
            other.SetActive(false);

        }
        else
        {
            if(lifes!=0)
            {
                Time.timeScale = 1f;
                Over.SetActive(false);
                other.SetActive(true);
            }
        }
    }
    public void agregarvidas()
    {
        
        lifes++;
        

    }
    public void quitarvidas()
    {
        lifes--;
        

       
 
    }


}