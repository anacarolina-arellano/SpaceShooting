using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public GameObject enemyObject;
    public Transform[] spawnPoints;
    
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject pointsText;

    private TextMeshProUGUI myText;
    public bool gameOver = false;

    public float maxSpawnDelay;
    public float curSpawnDelay;
    public int points;
    public float health;
    [SerializeField] private Image barfill;

    private void Start()
    {
        Time.timeScale = 1;
        points = 0;
        health = 1.0f;
        gameOverText.SetActive(false);

    }
    void Update()
    {
        
        myText = pointsText.GetComponent<TextMeshProUGUI>();
        myText.SetText("Score: " + points.ToString());
        curSpawnDelay += Time.deltaTime;

        if(curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 2f);    // randomly generate spawn enemy
            curSpawnDelay = 0;
        }
        if(gameOver)
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
        }
        barfill.fillAmount = health == 0 ? 0f : health;
    }

    void SpawnEnemy()
    {
        int randomPosition = Random.Range(0, 10);
        Instantiate(enemyObject, spawnPoints[randomPosition].position, spawnPoints[randomPosition].rotation);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
