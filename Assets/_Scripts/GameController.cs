using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public GameObject[] powerups;
    public GameObject enemy;
    public Vector3 spawnValues;
    public int hazardCount;
    public int powerUpCount;
    public float spawnWait;
    public float spawnPorwerUpWait;
    public float spawnStart;
    public float waitWave;
    private float WaveCount;
    private Scene scene;

    public Text scoreText;
    public Text lifeText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private bool isCreated;
    private int score;

    private bool bossFight;

    private void Start()
    {
        WaveCount = 0;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());
        StartCoroutine (SpawnPowerUps());
        scene = SceneManager.GetActiveScene();
    }
    private void Update()
    {
        UpdateScore();
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(scene.name);
            }

        }
        if (WaveCount >= 5f)
        {
            BossFight();
        }
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(spawnStart);
        while(true)
        { 
            for (int i = 0 ;i<hazardCount ;i++ )
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            if (gameOver)
            {
                restartText.text = "press 'r' to restart the game";
                restart = true;
                break;
            }
            yield return new WaitForSeconds(waitWave);
            WaveCount++;
        }
    }

    private IEnumerator SpawnPowerUps()
    {
        yield return new WaitForSeconds(spawnStart);
        while (true)
        {
            for (int i = 0; i < powerUpCount; i++)
            {
                GameObject powerUpInstance = powerups[Random.Range(0, powerups.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(powerUpInstance, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnPorwerUpWait);
            }

            yield return new WaitForSeconds(waitWave);
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        
    }
    private void UpdateScore()
    {
        scoreText.text = "score: " + score;
        lifeText.text = "" + PlayerController.instace.health;

    }
    public void GameOver()
    {
        gameOverText.text = "game over!";
        gameOver = true;
    }

    public void BossFight()
    {
        hazardCount = 0;
        if (!isCreated)
        {
            Vector3 enemyPosition = new Vector3(3.62f, 0.0f, 22);
            Quaternion enemyRotation = new Quaternion(0, 180, 0, 1);
            Instantiate(enemy, enemyPosition, enemyRotation);
            isCreated = true; 
        }
        
    }
}
