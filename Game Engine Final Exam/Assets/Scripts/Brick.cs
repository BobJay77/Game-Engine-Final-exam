using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" && gameObject.tag == "Brick") 
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "EnemyBullet" && gameObject.tag == "House")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Lose");
        }
    }
}
