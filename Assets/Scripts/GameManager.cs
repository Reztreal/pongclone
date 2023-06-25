using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    static int playerScore = 0;
    static int aiScore = 0;
    BallController Ball;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI aiScoreText;
    public TextMeshProUGUI gameOverText;


    // Start is called before the first frame update
    void Start()
    {
        Ball = FindObjectOfType<BallController>();
        Ball.OnScore += Score;
    }

    // Update is called once per frame
    void Update()
    {
        CheckScore();
    }

    void Score(float position)
    {
        if (position < -8)
        {
            Ball.transform.position = Vector2.zero;
            Ball.speed = 5;
            aiScore++;
            aiScoreText.text = aiScore.ToString();
        }
        else if (position > 8)
        {
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
            gameOverText.text = "You Won!";
            gameOverText.gameObject.SetActive(true);
        }

        else if (aiScore == 3)
        {
            gameOverText.text = "You Lost!";
            gameOverText.gameObject.SetActive(true);
        }
    }

}
