using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Opciones : MonoBehaviour
{
   [SerializeField] private AudioMixer audiomix;
   public void cambvolumen(float volumen){
    audiomix.SetFloat("Volumen",volumen);
   }
   public void resolucion(int index){
    QualitySettings.SetQualityLevel(index);
   }
}
