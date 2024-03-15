using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{
    public GameObject Spawner1;
    public GameObject Spawner2;
    
    public GameObject Rock;
    private bool SwitchSpawn;


    public int maxNumberOfRocks;
    [HideInInspector] public int rockCount;
    private bool test = true;
    private void Start()
    {
        rockCount = 0;
    }

    private void Update()
    {
        if (rockCount < maxNumberOfRocks && test )
        {
            rockCount++;
            AddRock();
            test = !test;
        }
    }

    public void AddRock()
    {
        if (SwitchSpawn)
        {
            StartCoroutine(SpawnRock1());
        }
        else
        {
            StartCoroutine(SpawnRock2());
        }
        SwitchSpawn = !SwitchSpawn;
        
    }

    public void RemoveRock()
    {
            rockCount--;
    }
    IEnumerator SpawnRock1()
    {
        yield return new WaitForSeconds(1);
        Instantiate(Rock,Spawner1.transform.position , Quaternion.identity);
        Debug.Log(Time.time);
        test = !test;
    }
    IEnumerator SpawnRock2()
    {
        yield return new WaitForSeconds(1);
        Instantiate(Rock,Spawner2.transform.position , Quaternion.identity);
        Debug.Log(Time.time);
        test = !test;
    }
}
