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

    [SerializeField] int numberOfEnemy;
    [SerializeField] float SpawnFrequency;

    [HideInInspector] public int enemyCounter;
    [HideInInspector] public int numberOfWaves;
    [HideInInspector] public int[] numberOfEnemiesInWave;

    private bool isPlaying = false;

    private void Start()
    {
        isPlaying = true;
        enemyCounter = 0;
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
       /* while (isPlaying)
        {
            */if (enemyCounter == 0)
            {
                for (int i = 0; i < numberOfEnemy; i++)
                {
                    SpawnEnemy(i);
                    yield return new WaitForSeconds(SpawnFrequency);
                }
                yield return new WaitForSeconds(5);
            }
        /*}*/
    }

    public void SpawnEnemy(int enemyIndex)
    {
        GameObject enemyToSpawn = typeOfEnemies[0];
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
