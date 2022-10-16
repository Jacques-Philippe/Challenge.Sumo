using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    /// <summary>
    /// Our Game Manager reference.
    /// </summary>
    private GameManager gameManager;
    private RotateCamera rotateCamera;
    private PlayerMovement playerMovement;

    private Action inputScheme;


    private void Awake()
    {

        
        this.gameManager = GameObject.FindObjectOfType<GameManager>();
        this.rotateCamera = GameObject.FindObjectOfType<RotateCamera>();
        this.playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void Start()
    {

        this.inputScheme = GameInputScheme;
    }

    private void Update()
    {
        if (this.inputScheme != null)
        {
            this.inputScheme.Invoke();
        }
    }

    void OnEnable()
    {
        this.gameManager.OnGameOver += ChangeToGameOverInputScheme;
    }

    private void OnDisable()
    {
        this.gameManager.OnGameOver -= ChangeToGameOverInputScheme;
    }

    // Update is called once per frame
    void ChangeToGameOverInputScheme()
    {
        Debug.Log("Switched to Game Over input scheme");
        this.inputScheme = GameOverInputScheme;
    }

    void GameOverInputScheme()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    this.gameManager.ResetGame();
        //}
    }

    void GameInputScheme()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        if (horizontalAxis != 0.0f)
        {
            if (horizontalAxis > 0) { rotateCamera.RotateClockwise(); }
            else { rotateCamera.RotateCounterClockwise(); }
        }

        float verticalAxis = Input.GetAxis("Vertical");
        if (verticalAxis != 0.0f)
        {
            if (verticalAxis > 0) { this.playerMovement.MoveAwayFromCamera(); }
            else { this.playerMovement.MoveTowardsCamera(); }
        }
    }

}
