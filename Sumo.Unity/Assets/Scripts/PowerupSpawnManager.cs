using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawnManager : MonoBehaviour
{
    /// <summary>
    /// The enemy prefab to instantiate
    /// </summary>
    [SerializeField]
    private GameObject powerupPrefab;

    private float ARENA_X_MIN = -7.0f;
    private float ARENA_X_MAX = 7.0f;
    private float ARENA_Z_MIN = -7.0f;
    private float ARENA_Z_MAX = 7.0f;

    private float spawnHeight = 0.25f;

    /// <summary>
    /// Spawn a single enemy at a random position in our arena
    /// </summary>
    public void SpawnPowerup()
    {
        var position = GetRandomPositionInArena();
        GameObject.Instantiate(powerupPrefab, position: position, rotation: new Quaternion());
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
