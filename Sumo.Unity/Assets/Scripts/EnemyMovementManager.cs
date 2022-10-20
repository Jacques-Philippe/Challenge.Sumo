using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovementManager : MonoBehaviour
{
    private PlayerDeath playerDeath;
    private GameObject player;
    /// <summary>
    /// The arena
    /// </summary>
    private GameObject island;

    private Rigidbody rigidBody;

    private Action movementScheme;

    public float speed;

    private float maximumDistanceFromCentre = 7.0f;

    private void Awake()
    {
        this.playerDeath = GameObject.FindObjectOfType<PlayerDeath>();
        this.player = GameObject.Find("Player");

        this.rigidBody = this.GetComponent<Rigidbody>();
        this.island = GameObject.Find("Island");
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
        if (this.playerDeath != null)
        {
            this.playerDeath.OnPlayerDeath += SwitchToCircleArenaMovementScheme;
        }
    }

    private void OnDisable()
    {
        if (this.playerDeath != null)
        {
            this.playerDeath.OnPlayerDeath -= SwitchToCircleArenaMovementScheme;
        }
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
        if (player == null)
        {
            SwitchToCircleArenaMovementScheme();
        }
        Vector3 playerPosition = this.player.transform.position;
        Vector3 direction = playerPosition - this.transform.position;

        this.rigidBody.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode.Impulse);
    }

    void CircleArena()
    {
        Vector3 toIslandCenter = this.island.transform.position - this.transform.position;
        Vector3 right = Vector3.Cross(lhs: Vector3.up, rhs: toIslandCenter);
        bool isTooFarFromCentre = toIslandCenter.magnitude > this.maximumDistanceFromCentre;
        if (isTooFarFromCentre)
        {
            this.rigidBody.AddForce(toIslandCenter.normalized * speed * Time.deltaTime, ForceMode.Impulse);
        }
        else
        {
            this.rigidBody.AddForce((2 * toIslandCenter + right).normalized * speed * Time.deltaTime, ForceMode.Impulse);
        }

    }
}
