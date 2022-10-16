using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver { get; private set; } = false;

    public delegate void GameOverListener();
    public GameOverListener OnGameOver;

    private PlayerDeath playerDeath;

    private void Awake()
    {
        this.playerDeath = GameObject.FindObjectOfType<PlayerDeath>();
    }

    private void OnEnable()
    {
        this.playerDeath.OnPlayerDeath += EndGame;
    }

    private void OnDisable()
    {
        this.playerDeath.OnPlayerDeath -= EndGame;
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

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        this.EndGame();
    //    }
    //}
}
