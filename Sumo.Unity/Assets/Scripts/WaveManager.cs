using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int waveNumber { get; private set; } = 0;

    private SpawnManager spawnManager;
    private EnemySpawnManager enemySpawnManager;
    private GameManager gameManager;

    private void Awake()
    {
        this.spawnManager = FindObjectOfType<SpawnManager>();
        this.enemySpawnManager = FindObjectOfType<EnemySpawnManager>();
        this.gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        this.enemySpawnManager.OnAllEnemiesKilled += StartNextWave;
    }

    private void OnDisable()
    {
        this.enemySpawnManager.OnAllEnemiesKilled -= StartNextWave;
    }

    public void StartNextWave()
    {
        if (!this.gameManager.IsGameOver)
        {
            waveNumber++;

            Debug.Log($"Starting wave {waveNumber}");
            this.spawnManager.SpawnWaveContents(waveNumber: this.waveNumber);
        }
    }
}
