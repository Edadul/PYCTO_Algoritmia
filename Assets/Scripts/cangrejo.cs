using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cangrejo : MonoBehaviour
{
    [SerializeField] private float VelocityMov;
     [SerializeField] private Transform[] puntosMov;
      [SerializeField] private float Distancia;
      private int posaleatoria;
      private SpriteRenderer SP;
    void Start()
    {
        posaleatoria=Random.Range(0,puntosMov.Length);
        SP=GetComponent<SpriteRenderer>();
        Girar();
    }
    void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position,puntosMov[posaleatoria].position,VelocityMov*Time.deltaTime);
        if(Vector2.Distance(transform.position,puntosMov[posaleatoria].position)< Distancia){
            posaleatoria=posaleatoria=Random.Range(0,puntosMov.Length);
            Girar();
        }

    }
    private void Girar(){
        if(transform.position.x <puntosMov[posaleatoria].position.x){
            SP.flipX=true;
        }else{
            SP.flipX=false;
        }
    }
}
