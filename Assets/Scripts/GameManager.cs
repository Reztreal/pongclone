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


    // Start is called before the first frame update
    void Start()
    {
        Ball = FindObjectOfType<BallController>();
        Ball.OnScore += Score;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Score(float position)
    {
        if (position < -8)
        {
            Ball.transform.position = Vector2.zero;
            Ball.speed = 5;
            playerScore++;
            playerScoreText.text = playerScore.ToString();
        }
        else if (position > 8)
        {
            Ball.transform.position = Vector2.zero;
            Ball.speed = 5;
            aiScore++;
            aiScoreText.text = aiScore.ToString();
        }

    }

}
