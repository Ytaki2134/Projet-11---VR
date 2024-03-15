using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 50;
    public bool burn;
    public bool freeze;
    public bool shock;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.layer)
        {
            case 7 :
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                enemy.currentHealth -= damage; 
                if (burn)
                {
                    enemy.StartBurning(damage);
                }
                if (freeze)
                {
                    enemy.StartFreezing();
                }
                if (shock)
                {
                    enemy.StartShocking();
                }
                Destroy(gameObject);
                break;
        }

    }
}
