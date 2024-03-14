using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnRock_Tuto : MonoBehaviour
{
    public float respawn = -10f;
    private  Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y< respawn)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = respawnPoint;
        }
    }
}
