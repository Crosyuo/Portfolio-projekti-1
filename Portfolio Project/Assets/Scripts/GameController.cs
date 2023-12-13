using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] public TMP_Text _livesText;
    public GameObject canvas;
    public GameObject youLostText;
    static int points = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.activeInHierarchy == false)
            {
                canvas.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                canvas.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    void Start()
    {
        _pointsText.text = points.ToString();
    }

    public void pointsChange(int pointz)
    {
        points += pointz;
        _pointsText.text = points.ToString();
    }

    public void gameLost()
    {
        resetPoints();
        canvas.SetActive(true);
        youLostText.SetActive(true);
        Time.timeScale = 0;
        this.enabled = false;
    }

    public void gameWon()
    {
        SceneManager.LoadScene(1);
    }

    public void resetPoints()
    {
        points = 0;
    }
}