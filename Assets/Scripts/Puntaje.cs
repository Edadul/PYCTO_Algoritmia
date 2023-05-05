using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Puntaje : MonoBehaviour
{
    private float scoore;
    private TextMeshProUGUI textMesh;
    [SerializeField] private Cant_vidas aux;
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {

        textMesh.text = scoore.ToString("0");
    }
    public void SumarScoore(float Puntos)
    {
        scoore += Puntos;
        if (scoore % 200 == 0)
        {
            aux.agregarvidas();
        }
    }
    
}