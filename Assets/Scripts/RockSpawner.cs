using System.Collections;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private float RespawnSpeed;

    [SerializeField] RockManager manager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRock());
    }

    private void Update()
    {
        if (manager.rockCount < manager.maxNumberOfRocks)
        {
            StartCoroutine(SpawnRock());
        }
    }


    IEnumerator SpawnRock()
    {
        while (manager.rockCount < manager.maxNumberOfRocks)
        {
            Instantiate(manager.Rock, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            manager.AddRock();
            yield return new WaitForSeconds(RespawnSpeed);
        }
    }

    public void SetRock(GameObject newRock)
    {
        manager.Rock = newRock;
    }
}
