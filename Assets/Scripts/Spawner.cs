using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    private float minX,maxX, minY, maxY;
    [SerializeField] private Transform[] Spawn;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempo;
    private float tiemposgtenemy;
    void Start()
    {

        maxX = Spawn.Max(Spawn => Spawn.position.x);
        minX = Spawn.Min(Spawn => Spawn.position.x);
        maxY = Spawn.Max(Spawn => Spawn.position.y);
        minY = Spawn.Min(Spawn => Spawn.position.y);

    }

    void Update()
    {

        tiemposgtenemy += Time.deltaTime;
        if (tiemposgtenemy >= tiempo)
        {

            tiemposgtenemy = 0;
            Generarenemigo();

        }

    }
    private void Generarenemigo()
    {

        int numeroEnemigo = Random.Range(0,enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);

    }
}
