using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int hp;
    public int totalDamage = 0;

    private void Update()
    {
        Debug.Log(hp);
        if (hp <= 0)
            Defeat();
    }

    private void Start()
    {
        StartCoroutine(TakeDamage());
    }

    private IEnumerator TakeDamage()
    {
        while (hp > 0)
        {
            hp -= totalDamage;
            yield return new WaitForSeconds(1.3f);
        }
    }

    private void Defeat()
    {
        // Show Defeat
    }
}
