using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovementManager : MonoBehaviour
{
    private PlayerDeath playerDeath;
    private GameObject player;

    private Rigidbody rigidBody;

    private Action movementScheme;

    public float speed;

    private void Awake()
    {
        this.playerDeath = GameObject.FindObjectOfType<PlayerDeath>();
        this.player = GameObject.Find("Player");

        this.rigidBody = this.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (this.player != null)
        {
            movementScheme = MoveTowardsPlayer;
        }
        else
        {
            movementScheme = CircleArena;
        }
    }

    private void OnEnable()
    {
        this.playerDeath.OnPlayerDeath += SwitchToCircleArenaMovementScheme;
    }

    private void OnDisable()
    {
        this.playerDeath.OnPlayerDeath -= SwitchToCircleArenaMovementScheme;
    }

    private void Update()
    {
        this.movementScheme.Invoke();
    }

    void SwitchToCircleArenaMovementScheme()
    {
        this.movementScheme = CircleArena;
    }

    void MoveTowardsPlayer()
    {
        Vector3 playerPosition = this.player.transform.position;
        Vector3 direction = playerPosition - this.transform.position;

        this.rigidBody.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode.Impulse);
    }

    void CircleArena()
    {
        Debug.Log("Circling arena");
    }
}
