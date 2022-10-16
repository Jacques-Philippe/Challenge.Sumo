using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    EnemySpawnManager enemySpawnManager;

    private void Awake()
    {
        this.enemySpawnManager = this.GetComponent<EnemySpawnManager>();
    }

    public void SpawnWaveContents(int waveNumber)
    {
        int numEnemies = waveNumber;
        this.enemySpawnManager.SpawnEnemies(numEnemies);
    }
}
