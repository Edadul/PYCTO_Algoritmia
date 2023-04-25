using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Puntaje : MonoBehaviour
{
   private float scoore; 
   private TextMeshProUGUI textMesh;
    private void Start()
    {
        textMesh= GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        scoore+=Time.deltaTime;
        textMesh.text=scoore.ToString("0");
    }
    public void SumarScoore(float Puntos){
        scoore+=Puntos;
    }
}
