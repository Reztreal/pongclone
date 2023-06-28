using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    BallController Ball;
    public GameObject restartButton;
    public GameObject gameOverText;

    void Start()
    {
        Ball = FindObjectOfType<BallController>();
    }

    public void OnPlayButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
    
    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
