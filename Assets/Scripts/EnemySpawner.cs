using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject[] enemyToSpawn;

    [SerializeField] GameObject spawnPoint;

    [SerializeField] int numberOfEnemy;
    [SerializeField] int numberOfSpawn;

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < numberOfEnemy; i++)
        {
            Enemy e = new Enemy();
            e.transform.position = spawnPoint.transform.position;
        }
    }
}
