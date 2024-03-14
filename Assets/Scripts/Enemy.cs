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

    public void StartBurning(int damage)
    {
        StartCoroutine(Burning(damage));
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

    public void StartFreezing()
    {
        StartCoroutine(Freezing());
    }

    private IEnumerator Freezing()
    {
        ChangeMaterialColor(Color.blue);
        isMoving = false;
        yield return new WaitForSeconds(3);
        isMoving = true;
        ChangeMaterialColor(currentColor);
    }

    public void StartShocking()
    {
        StartCoroutine(Shocking());
    }

    private IEnumerator Shocking()
    {
        foreach (GameObject enemy in spawner.enemiesInWave)
        {
            if (Vector3.Distance(gameObject.transform.position, enemy.transform.position) < 2000000)
            {
                ChangeMaterialColor(new Color(1, .08f, .55f), enemy);
                if (enemy.GetComponent<Enemy>().currentHealth >= 0)
                {
                    enemy.GetComponent<Enemy>().currentHealth -= damage / 10;
                }
                yield return new WaitForSeconds(0.1f);
                ChangeMaterialColor(currentColor, enemy);
            }
        }
    }

    private void ChangeMaterialColor(Color newColor)
    {
        gameObject.GetComponentInChildren<Renderer>().material.color = newColor;
    }

    private void ChangeMaterialColor(Color newColor, GameObject enemyToChange)
    {
        enemyToChange.gameObject.GetComponentInChildren<Renderer>().sharedMaterial.color = newColor;
    }

    private IEnumerator Death()
    {
        spawner.enemyCounter--;
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
