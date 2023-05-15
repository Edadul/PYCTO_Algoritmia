using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private int min, secs, cent;
    private float tiempo,puntos;
    [SerializeField] private Timer time;
    [SerializeField] private Puntaje p;
    [SerializeField] private TMP_Text t;
    [SerializeField] private TMP_Text points;
    void Start()
    {
        tiempo = time.time;
        min = (int)(tiempo / 60f);
        secs = (int)(tiempo - min * 60f);
        cent = (int)((tiempo - (int)tiempo) * 1000f);
        puntos = p.scoore;
        t.text = string.Format("{0:00}:{1:00}:{2:00}", min, secs, cent);
        points.text = puntos.ToString();

    }
    public void restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void volver()
    {

        SceneManager.LoadScene("PANTALLA");

    }
}
