using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public TMP_Text scoreText;
    public GameObject badPlantPrefab;
    public GameObject goodPlantPrefab;
    public float spawnPeriodSeconds = 2f;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnPeriodSeconds);
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        float randomValue = Random.value;
        if (randomValue <= 0.2f)
        {
            Instantiate(badPlantPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
        else if (randomValue <= 0.3f)
        {
            Instantiate(goodPlantPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }

    void Update()
    {
        int score = int.Parse(scoreText.text.Replace("Score: ", "")); // Extract score from TMP_Text component
        if (score >= 20)
        {
            spawnPeriodSeconds = 1.5f;
        }
    }
}
