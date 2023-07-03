using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    static int playerScore = 0;
    static int aiScore = 0;
    public float screenWidth;
    public float screenHeight;
    BallController Ball;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI aiScoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject restartButton;
    public GameObject quitButton;
    private AudioSource source;
    public AudioClip scoreSound;


    // Start is called before the first frame update
    void Start()
    {
        Ball = FindObjectOfType<BallController>();
        source = GetComponent<AudioSource>();

        screenHeight = Camera.main.orthographicSize;
        screenWidth = Camera.main.aspect * screenHeight;
    }

    // Update is called once per frame
    void Update()
    {
        Score();
        CheckScore();
    }

    void Score()
    {
        if (Ball.transform.position.x < -(screenWidth))
        {
            source.clip = scoreSound;
            source.Play();
            Ball.transform.position = Vector2.zero;
            Ball.speed = 5;
            aiScore++;
            aiScoreText.text = aiScore.ToString();
        }
        else if (Ball.transform.position.x > screenWidth)
        {
            source.clip = scoreSound;
            source.Play();
            Ball.transform.position = Vector2.zero;
            Ball.speed = 5;
            playerScore++;
            playerScoreText.text = playerScore.ToString();

        }
    }

    void CheckScore()
    {
        if (playerScore == 3)
        {
            Ball.startGame = false;
            gameOverText.text = "You Won!";
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            playerScore = 0;
            aiScore = 0;
        }

        else if (aiScore == 3)
        {
            Ball.startGame = false;
            gameOverText.text = "You Lost!";
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            playerScore = 0;
            aiScore = 0;
        }
    }


}
