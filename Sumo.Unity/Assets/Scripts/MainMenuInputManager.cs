using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInputManager : MonoBehaviour
{
    private Action inputScheme;

    private void Start()
    {

        this.inputScheme = MainMenuInputScheme;
    }

    private void Update()
    {
        if (this.inputScheme != null)
        {
            this.inputScheme.Invoke();
        }
    }

    void MainMenuInputScheme()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Scenes/Main");
        }
    }

}
