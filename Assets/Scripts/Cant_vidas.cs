using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cant_vidas : MonoBehaviour
{
   [SerializeField] private Player_respawn res;
   [SerializeField] private Cant_rings compr;
    private float lifes=3; 
    private float var;
   
   private TextMeshProUGUI textMesh;
   private void Start()
    {
        textMesh= GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
       
      
        textMesh.text=lifes.ToString();
    }
    public void agregarvidas()
    {
        
        lifes=lifes+1;
        

    }
    public void quitarvidas()
    {
        lifes=lifes-1;
        
        if(lifes<1)
        {
            res.PlayerDamaged();
        }
    }
    

}