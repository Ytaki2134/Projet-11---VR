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

    [HideInInspector] public int enemyCounter;
    [HideInInspector] public int numberOfWaves;
    [HideInInspector] public int[] numberOfEnemiesInWave;

    [HideInInspector] public List<int[]> enemies = new List<int[]>();
    [HideInInspector] public List<GameObject> enemiesInWave = new List<GameObject>();
    [SerializeField] WavesSO waves;



    [SerializeField] GameObject Win;

    private int currentWave;
    private bool isPlaying = false;

    private void Start()
    {
        currentWave = 0;
        enemies = waves.enemies.Select(i => i.Enemies).ToList();
        isPlaying = true;
        enemyCounter = 0;
    }



    public void StartWave()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        if (currentWave < numberOfWaves)
        {
            currentWave++;
            for (int i = 0; i < typeOfEnemies.Length; i++)
            {
                for (int j = 0; j < enemies[currentWave - 1][i]; j++)
                {
                    SpawnEnemy(i);
                    yield return new WaitForSeconds(SpawnFrequency);
                }
            }
            yield return new WaitForSeconds(5);
        }
        else
        {
            Win.SetActive(true);
        }
    }

    public void SpawnEnemy(int enemyIndex)
    {
        GameObject enemyToSpawn = typeOfEnemies[enemyIndex];
        enemyToSpawn.transform.position = spawnPoint.transform.position + new Vector3(Random.Range(-150, 150), 0, 0);
        Instantiate(enemyToSpawn);
        enemiesInWave.Add(enemyToSpawn);

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
