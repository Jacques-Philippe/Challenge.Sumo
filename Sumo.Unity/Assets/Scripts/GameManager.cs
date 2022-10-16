using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver { get; private set; } = false;

    public delegate void GameOverListener();
    public GameOverListener OnGameOver;

    private WaveManager waveManager;

    private PlayerDeath playerDeath;

    private void Awake()
    {
        this.playerDeath = GameObject.FindObjectOfType<PlayerDeath>();
        this.waveManager = GameObject.FindObjectOfType<WaveManager>();
    }

    private void OnEnable()
    {
        this.playerDeath.OnPlayerDeath += EndGame;
    }

    private void OnDisable()
    {
        this.playerDeath.OnPlayerDeath -= EndGame;
    }

    private void Start()
    {
        this.waveManager.StartNextWave();
    }

    /// <summary>
    /// A function to be invoked when an end game condition has been met
    /// </summary>
    /// <remarks>Our only end game condition is when the player falls off the arena</remarks>
    public void EndGame()
    {
        Debug.Log("Game over");
        IsGameOver = true;
        OnGameOver.Invoke();
    }

    /// <summary>
    /// A function to be invoked when a game reset is desired
    /// </summary>
    public void ResetGame()
    {
        //reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
