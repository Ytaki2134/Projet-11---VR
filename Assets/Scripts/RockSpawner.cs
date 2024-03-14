using System.Collections;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Rock;
    [SerializeField] private float RespawnSpeed;
    [SerializeField] private int MaxCount;
    private int _RockCount;

    // Start is called before the first frame update
    void Start()
    {
        _RockCount = 0;

        StartCoroutine(SpawnRock());
    }


    IEnumerator SpawnRock()
    {
        while (_RockCount < MaxCount)
        {
            Instantiate(Rock, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            _RockCount++;
            yield return new WaitForSeconds(RespawnSpeed);
        }
    }
}
