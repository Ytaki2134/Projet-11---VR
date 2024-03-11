using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] typeOfEnemies;

    [SerializeField] GameObject spawnPoint;
    [SerializeField] float SpawnFrequency;
    [SerializeField] EnemiesSO enemySO;

    [HideInInspector] public int enemyCounter;
    [HideInInspector] public int numberOfWaves;
    [HideInInspector] public int[] numberOfEnemiesInWave;
    [HideInInspector] public List<int[]> enemies = new List<int[]>();

    private bool isPlaying = false;
    private int currentWave;

    private void Start()
    {
        currentWave = 0;
        isPlaying = true;
        enemyCounter = 0;
        //enemies.Add(new int[typeOfEnemies.Length]);
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {

        yield return new WaitForSeconds(5);
        /*while (isPlaying)
        {
            if (enemyCounter == 0)
            {
                currentWave++;
                for (int i = 0; i < typeOfEnemies.Length; i++)
                {
                    for (int j = 0; j < enemies[currentWave][i]; j++)
                    {
                        SpawnEnemy(i);
                        yield return new WaitForSeconds(SpawnFrequency);
                    }
                }
                
                yield return new WaitForSeconds(5);
            }
            if (currentWave == numberOfWaves)
            {
                isPlaying = false;
            }
        }*/
    }

    public void SpawnEnemy(int enemyIndex)
    {
        GameObject enemyToSpawn = typeOfEnemies[enemyIndex];
        enemyToSpawn.transform.position = spawnPoint.transform.position;
        Instantiate(enemyToSpawn);

        enemyCounter++;
    }

    public int[] AddArrayLenght(int[] arraytoUpdate)
    {
        int[] tempArray = arraytoUpdate;
        arraytoUpdate = new int[tempArray.Length + 1];
        for (int i = 0; i < tempArray.Length; i++ )
        {
            arraytoUpdate[i] = tempArray[i];
        }
        return arraytoUpdate;
    }

    public int[] RemoveArrayLenght(int[] arraytoUpdate)
    {
        int[] tempArray = arraytoUpdate;
        arraytoUpdate = new int[tempArray.Length - 1];
        for (int i = 0; i < tempArray.Length - 1; i++)
        {
            arraytoUpdate[i] = tempArray[i];
        }
        return arraytoUpdate;
    }
}
