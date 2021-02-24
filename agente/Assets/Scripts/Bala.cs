using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    //Variable creada para la velocidad de la bala
    //Public es para que el codigo sea visible
    //Float es la marca de que es una variable
    //5.0F es la velocidad de la bala
    public float speed = 1.0f;
    //Start is called before the first frame update
    //Los codigos que aqui se comenzaran a cargar desde el primer frame
    void Start()
    {
         
    }

    //Los codigos que aqui se estaran ejecutando continuamente con cada Frame
    //Update is called once per frame
    void Update()
    {
        //Transform es para llamar la ccion de transformar por objeto que se situa en el inspector de Unity
        //Lo de las coordenadas, tamaño y rotacion
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    
     private void OnTRiggerEnter(Collider Obj)
    {
        //If es un condicionante, si sucede x cosa va a pasar x reaccion, en caso contrario sucedera otra x cosa
        if (Obj.CompareTag("Player"))
        {
            Debug.Log("Impacto con el jugador");
            Destroy(this.gameObject);
        }
    }
}