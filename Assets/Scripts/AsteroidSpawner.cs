using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTimeMin = 0.5f;
    [SerializeField] private float spawnTimeMax = 3f;
    [SerializeField] private float spawnRadius = 1f;

    [SerializeField] private Asteroid asteroidPrefab;

    [SerializeField] private int simulatedAsteroids = 100;
    [ExecuteInEditMode]
    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log("Spawning asteroid");

        Vector3 startPosition = GetRandomPointArundCircle(spawnRadius);
        Vector3 endPosition = GetRandomPointArundCircle(spawnRadius);

        Asteroid asteroid = Instantiate(asteroidPrefab, startPosition, Quaternion.identity);
        asteroid.transform.LookAt(endPosition);
    }

    private Vector3 GetRandomPointArundCircle(float radius)
    {
        Vector2 point2D = Random.insideUnitCircle * radius;
        Vector3 point3D = new Vector3(point2D.x, 0f, point2D.y);

        return point3D;
    }

    private void OnDrawGizmos()
    {

        Color gizmoColor = Color.red;
        for (int i = 0; i <= simulatedAsteroids; i++)
        {
            Gizmos.color = gizmoColor;
            gizmoColor.g += 1f / simulatedAsteroids;
            Vector3 startPosition = GetRandomPointArundCircle(spawnRadius);
            Vector3 endPosition = GetRandomPointArundCircle(spawnRadius);
            Gizmos.DrawLine(startPosition, endPosition);
            Debug.Log("here");
           // Gizmos.DrawSphere(transform.position, 1);
        }
    }
}
