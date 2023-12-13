using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameController gameController;

    void awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void PlayGame()
    {
        if (gameController != null)
        {
            gameController.resetPoints();
        }

        SceneManager.LoadScene(1);
    }

    public void MainMenuEnter()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        if (gameController != null)
        {
            gameController.resetPoints();
        }

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Time.timeScale = 1;
        if (gameController != null)
        {
            gameController.resetPoints();
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Meow");
        }
        
    }
}
