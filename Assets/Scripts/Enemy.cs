using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner spawner;

    [HideInInspector] public GameObject targetToFocus;

    public int maxHealth;
    public int damage;
    public int speed;
    public int goldOnDrop;

    [HideInInspector] public int currentHealth;
    [HideInInspector] public bool isMoving = true;
    private Color currentColor;

    void Start()
    {
        currentColor = gameObject.GetComponentInChildren<Renderer>().material.color;
        spawner = GameObject.FindWithTag("Spawner").GetComponent<EnemySpawner>();
        targetToFocus = GameObject.FindWithTag("Base");
        currentHealth = maxHealth;
    }

    private void Update()
    {
        var step = speed * Time.deltaTime;
        if (isMoving == true) 
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetToFocus.transform.position, step);
        }

        if (currentHealth <= 0) 
        {
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        spawner.enemyCounter--;
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            GameObject collidedObject = other.gameObject;
            currentHealth -= collidedObject.GetComponent<Projectile>().damage;

            if (collidedObject.GetComponent<Projectile>().burn == true)
                StartCoroutine(Burning(collidedObject.GetComponent<Projectile>().damage));

            if (collidedObject.GetComponent<Projectile>().freeze == true)
                StartCoroutine(Freezing());
        }
    }

    private IEnumerator Burning(int damage)
    {
        ChangeMaterialColor(Color.red);
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.95f);
            if (currentHealth >= 0)
            {
                currentHealth -= damage / 10;
            }
            ChangeMaterialColor(new Color(1, .6f, 0));
            yield return new WaitForSeconds(0.05f);
            ChangeMaterialColor(Color.red);
        }
        ChangeMaterialColor(currentColor);
    }

    private IEnumerator Freezing()
    {
        ChangeMaterialColor(Color.blue);
        isMoving = false;
        yield return new WaitForSeconds(3);
        isMoving = true;
        ChangeMaterialColor(currentColor);
    }

    private void ChangeMaterialColor(Color newColor)
    {
        gameObject.GetComponentInChildren<Renderer>().material.color = newColor;
    }
}
