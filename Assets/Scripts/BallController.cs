using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class BallController : MonoBehaviour
{
    
    public float speed = 5;
    [SerializeField]
    private float bounceAngle;
    private float screenHeight;
    private float ballHeight;
    private float topBound;
    private float screenWidth;
    public bool startGame = false;
    private Vector2 direction = Vector2.left;

    private PaddleController paddleControllerScript;
    public TextMeshProUGUI timerText;
    private AudioSource source;
    public AudioClip collisionSound, countdownShort, countdownLong;

    // Start is called before the first frame update
    void Start()
    {
        paddleControllerScript = GameObject.Find("Paddle 1").GetComponent<PaddleController>();
        source = GetComponent<AudioSource>();

        bounceAngle = UnityEngine.Random.Range(-.5f, .5f);
        screenHeight = Camera.main.orthographicSize;
        screenWidth = Camera.main.aspect * screenHeight;
        ballHeight = transform.localScale.y / 2;
        topBound = screenHeight - ballHeight;

        StartCoroutine(Countdown(3));
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            Move();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Paddle")
        {
            source.clip = collisionSound;
            source.Play();
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
        transform.Translate(direction * speed * Time.deltaTime);
        transform.Translate(Vector2.up * speed * bounceAngle * Time.deltaTime);
        source.clip = collisionSound;

        if (transform.position.x < -screenWidth)
        {
            bounceAngle = UnityEngine.Random.Range(-.5f, .5f);
            direction = Vector2.left;
        }

        if (transform.position.x > screenWidth)
        {
            bounceAngle = UnityEngine.Random.Range(-.5f, .5f);
            direction = Vector2.right;
        }

        if (transform.position.y > topBound)
        {
            source.Play();
            transform.position = new Vector2(transform.position.x, topBound);
            bounceAngle *= -1;

        }

        else if (transform.position.y < -topBound)
        {
            source.Play();
            transform.position = new Vector2(transform.position.x, -topBound);
            bounceAngle *= -1;
        }
    }

    
    IEnumerator Countdown (int seconds) {
        int counter = seconds;
        source.clip = countdownShort;
        while (counter > 0) {
            source.Play();
            timerText.text = counter.ToString();
            yield return new WaitForSeconds (1);
            counter--;
        }
        source.clip = countdownLong;
        source.Play();
        yield return new WaitForSeconds (.4f);
        timerText.gameObject.SetActive(false);
        startGame = true;
    }
}