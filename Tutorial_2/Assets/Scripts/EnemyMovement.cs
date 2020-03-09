using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private float startPositionX;

    private float startPositionY;
    bool GoRight = true;
    private Rigidbody2D rd2d;
    // Start is called before the first frame update
    void Start()
    {
        startPositionX = transform.position.x;
        startPositionY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPositionX)
        {
            GoRight = true;
        }
        if (transform.position.x > startPositionX + 10)
            GoRight = false;

        if (GoRight)
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }
}
