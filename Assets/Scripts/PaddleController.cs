using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float speed = 10;
    private float screenHeight;
    private float playerHeight;
    private float topBound;
    public int moveDir;

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
        float inputY = Input.GetAxisRaw("Vertical");
        float velocity  = inputY * speed;

        transform.Translate(Vector3.up * velocity * Time.deltaTime);

        if (velocity > 0)
        {
            moveDir = 1;
        }
        else if (velocity < 0)
        {
            moveDir = 2;
        }
        else
        {
            moveDir = 3;
        }

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
