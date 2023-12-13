using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameController gameController;

    void start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void PlayGame()
    {
        if(gameController != null)
        {
            gameController.resetPoints();
        }

        SceneManager.LoadScene(1);
    }

    public void MainMenuEnter()
    {
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
        if (gameController != null)
        {
            gameController.resetPoints();
        }

        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
