using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStats eStats;

    [SerializeField]
    private int currentHealth;

    void Start()
    {
        currentHealth = eStats.maxHealth;
    }
}
