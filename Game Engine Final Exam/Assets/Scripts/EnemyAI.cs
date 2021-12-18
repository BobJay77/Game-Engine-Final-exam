using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject bullet;
    private GameObject basicpool;
    Rigidbody2D rigidbody2D;
    float horizontal, vertical;
    bool isMoving = false;
    [SerializeField] private float speed = 5f;
    enum Direction { Up, Down, Left, Right };
    Direction[] direction = { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        RandomDirection();
    }
    public void RandomDirection()
    {
        Direction selection = direction[Random.Range(0, 4)];
        if (selection == Direction.Up)
        {
            vertical = 1;
            horizontal = 0;
        }
        if (selection == Direction.Down)
        {
            vertical = -1;
            horizontal = 0;
        }
        if (selection == Direction.Right)
        {
            vertical = 0;
            horizontal = 1;
        }
        if (selection == Direction.Left)
        {
            vertical = 0;
            horizontal = -1;
        }
        isMoving = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet")
        {
            FindObjectOfType<Score>().score++;
            basicpool.GetComponent<BasicPool>().AddToPool(gameObject);
        }

        RandomDirection();
    }

    public void SetPool(GameObject pool)
    {
        basicpool = pool;
    }

    void Update()
    {
        if (vertical != 0 && isMoving == false)
        {
            rigidbody2D.velocity = new Vector2(horizontal * speed, vertical * speed);

            if (vertical == 1)
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, 0), 1);
            }

            else if (vertical == -1)
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, 180), 1);
            }

            isMoving = true;
        }

        else if (horizontal != 0 && isMoving == false)
        {
            rigidbody2D.velocity = new Vector2(horizontal * speed, vertical * speed);

            if(horizontal == 1)
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, -90), 1);
            }

            else if (horizontal == -1)
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, 90), 1);
            }

            isMoving = true;
        } 
    }
}