using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTimeMin = 0.25f;
    [SerializeField] private float spawnTimeMax = 3f;

    [SerializeField] private Asteroid asteroidPrefab;
    [SerializeField] private BoxCollider2D myBox;
    [SerializeField] private float x1;
    [SerializeField] private float y1;

    // Start is called before the first frame update
    void Start()
    {
        myBox = myBox.gameObject.GetComponent<BoxCollider2D>();
        this.StartCoroutine(SpawnCoroutine());
    }


    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetRandomSpawnDelay());

            SpawnAsteroid();
        }
    }

    private float GetRandomSpawnDelay()
    {
        return Random.Range(spawnTimeMin, spawnTimeMax);
    }

    private void SpawnAsteroid()
    {
        x1 = Random.Range(myBox.bounds.min.x, myBox.bounds.max.x);
        y1 = myBox.bounds.min.y;

        Asteroid asteroid = Instantiate(asteroidPrefab, new Vector3(x1, y1, 0), Quaternion.identity);

        //I want to destroy the asteroids even if  they weren't hit by a bullet
        //it's not working
        Destroy(asteroid, 5);
    }
}
