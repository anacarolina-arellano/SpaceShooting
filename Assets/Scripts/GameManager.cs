using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyObject;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 2f);    // randomly generate spawn enemy
            curSpawnDelay = 0;
        }
    }

    void SpawnEnemy()
    {
        int randomPosition = Random.Range(0, 10);
        Instantiate(enemyObject, spawnPoints[randomPosition].position, spawnPoints[randomPosition].rotation);
    }
}
