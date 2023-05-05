using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cant_rings : MonoBehaviour
{
    private float cant; 
    private float aux4;
    private TextMeshProUGUI textMesh;
    
   
     private void Start()
    {
        textMesh= GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {

        textMesh.text=cant.ToString("0");
        comp_rings(aux4);
       
        
    }
    public void Rings()
    {
        cant=cant+1;
    }
    public void comp_rings(float aux3)
    {
        if(cant>0){
            aux3=1;
        }else{
            aux3=0;
        }
        
        
    }
    public void zeroring(){
        cant=0;
    }
    
}