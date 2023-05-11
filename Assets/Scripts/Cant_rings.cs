using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Cant_rings : MonoBehaviour
{
    public float cant=0; 
    private float aux4;
    private TextMeshProUGUI textMesh;
    [SerializeField] private Damage DAM;
     private void Start()
    {
        textMesh= GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {

        textMesh.text=cant.ToString("0"); 
       
        
    }
    public void Rings()
    {
        cant=cant+1;
    }
    
    public void zeroring(){
        cant=0;
    }
    
    
}