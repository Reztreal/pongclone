using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static int playerScore = 0;
    static int aiScore = 0;
    BallController Ball;

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
            aiScore++;
        }
        else if (position > 8)
        {
            playerScore++;
        }

    }

}
