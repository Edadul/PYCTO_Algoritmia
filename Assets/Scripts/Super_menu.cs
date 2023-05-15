using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Super_menu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject other;
    [SerializeField] private Player_Movement pl;
    
    public void resumen()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        other.SetActive(true);
        pl.active = false;
    }
    
}
