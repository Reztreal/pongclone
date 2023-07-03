using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{   
    [SerializeField] private GameObject ball;
    [SerializeField] private float speed = 0.7f;
    private float screenHeight;
    private float playerHeight;
    private float topBound;

    // Start is called before the first frame update
    void Start()
    {

        screenHeight = Camera.main.orthographicSize;
        playerHeight = transform.localScale.y / 2;
        topBound = screenHeight - playerHeight;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, ball.transform.position.y * speed);

        if (transform.position.y > topBound)
        {
            transform.position = new Vector2(transform.position.x, topBound);
        }

        else if (transform.position.y < -topBound)
        {
            transform.position = new Vector2(transform.position.x, -topBound);
        }
    }
}
