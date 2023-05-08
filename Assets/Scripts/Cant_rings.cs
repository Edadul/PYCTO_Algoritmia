using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cant_rings : MonoBehaviour
{
    public float cant; 
    private float aux4;
    private TextMeshProUGUI textMesh;
    [SerializeField] private Damage DAM;
    public float sw;
   
     private void Start()
    {
        textMesh= GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {

        textMesh.text=cant.ToString("0");
        comp();
       
        
    }
    public void Rings()
    {
        cant=cant+1;
    }
    
    public void zeroring(){
        cant=0;
    }
    public void comp()
    {
        if(cant>0)
        {
            sw=1;
        }else{
            sw=0;
        }

    }
    
}