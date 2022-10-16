using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    /// <summary>
    /// The enemy prefab to instantiate
    /// </summary>
    [SerializeField]
    private GameObject enemyPrefab;

    /// <summary>
    /// the number of remaining enemies given the current wave
    /// </summary>
    private int numRemainingEnemies = 0;

    public delegate void AllEnemiesKilledAction();
    /// <summary>
    /// The event invoked when all enemies have been killed
    /// </summary>
    public AllEnemiesKilledAction OnAllEnemiesKilled;

    private float ARENA_X_MIN = -7.0f;
    private float ARENA_X_MAX = 7.0f;
    private float ARENA_Z_MIN = -7.0f;
    private float ARENA_Z_MAX = 7.0f;

    private float spawnHeight = 1.0f;

    public void SpawnEnemies(int numEnemies)
    {
        for(int i = 0; i < numEnemies; i++)
        {
            this.SpawnEnemy();
        }
    }

    private void RemoveEnemy()
    {
        this.numRemainingEnemies--;
        if (this.numRemainingEnemies == 0)
        {
            OnAllEnemiesKilled.Invoke();
        }
    }

    /// <summary>
    /// Spawn a single enemy at a random position in our arena
    /// </summary>
    private void SpawnEnemy()
    {
        var position = GetRandomPositionInArena();
        var enemy = GameObject.Instantiate(enemyPrefab, position: position, rotation: new Quaternion());
        enemy.GetComponent<EnemyDeath>().OnEnemyDeath += RemoveEnemy;
        this.numRemainingEnemies++;
    }

    /// <summary>
    /// Return a position from somewhere random in our arena
    /// </summary>
    /// <returns></returns>
    private Vector3 GetRandomPositionInArena()
    {
        float x = Random.Range(ARENA_X_MIN, ARENA_X_MAX);
        float z = Random.Range(ARENA_Z_MIN, ARENA_Z_MAX);
        return new Vector3(x, spawnHeight, z);
    }


}
