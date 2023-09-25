using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject asteroidPrefab2; //asteroide que aparecera al fragmentarse el anterior con la bala
    
    public float speed = 10f;   // parametros de la bala
    public float maxLifeTime = 3f;
    public Vector3 targetVector;

    private Vector3 scaleChange = new Vector3(0.15f,0.15f,0.15f);   // cambio de escala para el asteroide
    private Vector3 positionTransform1 = new Vector3(0.6f,0.1f,0f);

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,maxLifeTime); // despues de un tiempo maximo destruimos la bala
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")) // si el asteroide aun no se ha dividido ninguna vez, lo dividimos y destruimos el anterior
        {  
            DuplicarAsteroide(collision);
            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
        if(collision.gameObject.CompareTag("Enemy2")) // si ya ha sido destruido alguna vez, pasamos por aqui
        {  
            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void IncreaseScore()
    {
        Player.SCORE++; // aumentamos la puntuacion
        UpdateScoreText();  // vamos a actualizarla
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI"); // seleccionamos el score
        go.GetComponent<Text>().text = "Puntos: " + Player.SCORE;
    }

    private void DuplicarAsteroide(Collision collision)
    {
        GameObject asteroid = Instantiate(asteroidPrefab2,collision.transform.position + positionTransform1,Quaternion.identity); // creamos uno de los trozos
        //asteroid.transform.localScale -= scaleChange;
        GameObject asteroid2 = Instantiate(asteroidPrefab2,collision.transform.position - positionTransform1 ,Quaternion.identity); // el otro
        // asteroid2.transform.localScale -= scaleChange;
        Destroy(asteroid,maxLifeTime); // los destruimos
        Destroy(asteroid2,maxLifeTime);
    }
}
