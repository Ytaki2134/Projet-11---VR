using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner spawner;

    private GameObject targetToFocus;

    public int maxHealth;
    public int damage;
    public int speed;

    private int currentHealth;

    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner").GetComponent<EnemySpawner>();
        targetToFocus = GameObject.FindWithTag("Base"); // A revoir 
        currentHealth = maxHealth;
    }

    private void Update()
    {
        var step = speed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetToFocus.transform.position, step);

        if (currentHealth <= 0) 
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
        spawner.enemyCounter--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeathTest")
        {
            currentHealth -= 200;
        }
    }
}
