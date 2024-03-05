using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject[] enemiesToSpawn;

    [SerializeField] GameObject spawnPoint;

    [SerializeField] int numberOfEnemy;
    [SerializeField] float SpawnFrequency;

    private void Start()
    {      
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < numberOfEnemy; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(SpawnFrequency);
        }
    }

    public void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemiesToSpawn.Count());
        GameObject enemyToSpawn = enemiesToSpawn[enemyIndex];
        enemyToSpawn.transform.position = spawnPoint.transform.position;
        Instantiate(enemyToSpawn);
    }
}
