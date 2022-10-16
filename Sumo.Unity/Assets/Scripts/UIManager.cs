using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// The UI to be shown while the game is in progress
    /// </summary>
    [SerializeField]
    private GameObject gameUI;

    /// <summary>
    /// The UI to be shown on game over
    /// </summary>
    [SerializeField]
    private GameObject gameOverUI;

    private GameManager gameManager;
    private WaveManager waveManager;

    /// <summary>
    /// The UI manager for the state of the gameUI interface
    /// </summary>
    private GameUI_UIManager gameUI_UIManager;

    /// <summary>
    /// The UI manager for the state of the gameOverUI interface
    /// </summary>
    private GameOverUI_UIManager gameOverUI_UIManager;

    private void Awake()
    {
        this.gameManager = FindObjectOfType<GameManager>();
        this.waveManager = FindObjectOfType<WaveManager>();

        this.gameUI_UIManager = FindObjectOfType<GameUI_UIManager>(true);

        this.gameOverUI_UIManager = FindObjectOfType<GameOverUI_UIManager>(true);
    }

    private void OnEnable()
    {
        this.gameManager.OnGameOver += ShowGameOverUI;
        this.waveManager.OnWaveStarted += UpdateGameUI;
    }

    private void OnDisable()
    {
        this.gameManager.OnGameOver -= ShowGameOverUI;
        this.waveManager.OnWaveStarted -= UpdateGameUI;
    }

    /// <summary>
    /// Update the 
    /// </summary>
    private void UpdateGameUI()
    {
        int waveNumber = this.waveManager.waveNumber;
        this.gameUI_UIManager.WaveNumber = waveNumber;
    }


    /// <summary>
    /// Stop showing the game UI and show the game over UI
    /// </summary>
    private void ShowGameOverUI()
    {
        this.gameUI.SetActive(false);
        this.gameOverUI.SetActive(true);
        this.gameOverUI_UIManager.WaveNumber = this.waveManager.waveNumber;
    }
}
