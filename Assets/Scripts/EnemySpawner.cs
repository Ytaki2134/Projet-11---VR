using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] typeOfEnemies;
    public int[][] enemiesToSpawn = new int[0][];

    [SerializeField] GameObject spawnPoint;

    [SerializeField] int numberOfEnemy;
    [SerializeField] float SpawnFrequency;

    [HideInInspector] public int enemyCounter;
    [HideInInspector] public int numberOfWaves;

    private bool isPlaying = false;

    private void Start()
    {
        isPlaying = true;
        enemyCounter = 0;
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (isPlaying)
        {
            if (enemyCounter == 0)
            {
                for (int i = 0; i < numberOfEnemy; i++)
                {
                    SpawnEnemy(i);
                    yield return new WaitForSeconds(SpawnFrequency);
                }
                yield return new WaitForSeconds(5);
            }
            numberOfEnemy = enemiesToSpawn[0].Length;
        }
    }

    public void SpawnEnemy(int enemyIndex)
    {
        GameObject enemyToSpawn = typeOfEnemies[enemiesToSpawn[0][enemyIndex]];
        enemyToSpawn.transform.position = spawnPoint.transform.position;
        Instantiate(enemyToSpawn);

        enemyCounter++;
    }

    public int[][] UpdateArray(int[][] arraytoUpdate)
    {
        int[][] tempArray = arraytoUpdate;
        arraytoUpdate = new int[arraytoUpdate.Length + 1][];
        for (int i = 0; i < tempArray.Length; i++)
        {
            for (int j = 0; j < tempArray[i].Length; j++)
            {
                arraytoUpdate[i][j] = tempArray[i][j];
            }
        }
        return arraytoUpdate;
    }
}
