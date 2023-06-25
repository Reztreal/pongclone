using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BallController : MonoBehaviour
{
    
    public float speed = 5;
    [SerializeField]
    private float bounceAngle;
    private float screenHeight;
    private float ballHeight;
    private float topBound;
    private float screenWidth;

    private PaddleController paddleControllerScript;

    public event Action<float> OnScore;

    // Start is called before the first frame update
    void Start()
    {
        paddleControllerScript = GameObject.Find("Paddle 1").GetComponent<PaddleController>();

        bounceAngle = UnityEngine.Random.Range(-.5f, .5f);
        screenHeight = Camera.main.orthographicSize;
        screenWidth = Camera.main.aspect * screenHeight;
        ballHeight = transform.localScale.y / 2;
        topBound = screenHeight - ballHeight;

        Debug.Log(screenWidth);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (transform.position.x < -screenWidth || transform.position.x > screenWidth)
        {
            OnScore(transform.position.x);
        }


    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Paddle")
        {
            speed *= -1;
            speed += Mathf.Sign(speed);
            
            if (bounceAngle > 0 && paddleControllerScript.moveDir == 1)
            {
                bounceAngle *= -1;
            }

            else if (bounceAngle < 0 && paddleControllerScript.moveDir == 2)
            {
                bounceAngle *= -1;
            }

            else
            {
                bounceAngle = UnityEngine.Random.Range(-.3f, .3f);
            }


        }
    }

    void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        transform.Translate(Vector2.up * speed * bounceAngle * Time.deltaTime);


        if (transform.position.y > topBound)
        {
            transform.position = new Vector2(transform.position.x, topBound);
            bounceAngle *= -1;
        }

        else if (transform.position.y < -topBound)
        {
            transform.position = new Vector2(transform.position.x, -topBound);
            bounceAngle *= -1;
        }
    }
}