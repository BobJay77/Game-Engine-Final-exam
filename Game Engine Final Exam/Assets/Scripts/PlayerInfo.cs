using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    private float horizontal;
    private float vertical;
    [SerializeField] private float speed = 8f;
    public float health = 3;

    // Update is called once per frame
    void Update()
    {
        vertical = 0;
        horizontal = 0;

        if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, -90), 1);
        }
       
       else if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, 90), 1);
        }


        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, 0), 1);
        }
      
        else if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, 180), 1);
        }
       
        rigidbody2D.velocity = new Vector2(horizontal * speed, vertical * speed);


        if (Input.GetKey(KeyCode.Space))
        {
            //shoot
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            health--;
        }
    }
}
