using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject asteroidPrefab;

    public float spawnRatePerMinute = 30f;
    public float spwanRateIncrement = 1f;

    public float xlimit; // limite de aparicion de los asteroides en el eje X
    public float maxLifeTime = 4f; // tiempo maximo de vida de cada asteroide 


    private float spawnNext = 0;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinute;

            spawnRatePerMinute += spwanRateIncrement;

            float rand = Random.Range(-xlimit,xlimit);

            Vector2 spawnPosition = new Vector2(rand, 6f); // elegimos una ubicacion aleatoria para que aparezca

            GameObject meteor = Instantiate(asteroidPrefab,spawnPosition,Quaternion.identity); // lo creamos

            Destroy(meteor,maxLifeTime); // si pasa el tiempo de vida, lo destruimos
        }
    }
}
