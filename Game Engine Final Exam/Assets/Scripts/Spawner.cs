using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    int numberofEnemies = 5;
    private float spawnRate = 1f, lastTime = 0;

    void Update()
    {
        if(Time.time-lastTime> spawnRate)
        {
            if (numberofEnemies < 6) 
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = BasicPool.Instance.GetFromPool();
        enemy.transform.position = transform.position;


    }


}
