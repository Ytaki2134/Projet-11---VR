using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using Unity.VisualScripting.YamlDotNet.Core;

public class WaveEditor : EditorWindow
{   
    public Vector2 scrollPosition = Vector2.zero;
    static int[][] numberOfEnemies;

    [MenuItem("Waves/Waves Editor")]
    public static void ShowWindow() 
    { 
        WaveEditor window = GetWindow<WaveEditor>();
        window.titleContent = new GUIContent("Waves Editor");
    }

    public void OnGUI()
    {
        EnemySpawner spawner = GameObject.FindWithTag("Spawner").GetComponent<EnemySpawner>();
        numberOfEnemies = spawner.enemiesToSpawn;

        if (GUI.Button(new Rect(10, 10, 100, 30), "Add Wave"))
        {
            spawner.numberOfWaves++;
            spawner.enemiesToSpawn = spawner.UpdateArray(spawner.enemiesToSpawn);
            Debug.Log(spawner.enemiesToSpawn.Length);
            numberOfEnemies = spawner.enemiesToSpawn;
        }
        
        if (GUI.Button(new Rect(120, 10, 100, 30), "Remove Wave"))
            if (spawner.numberOfWaves > 0)
                spawner.numberOfWaves--;

        scrollPosition = GUI.BeginScrollView(new Rect(10, 40, 300, 400), scrollPosition, new Rect(0, 0, 220, 40 * spawner.numberOfWaves));

        for (int i = 0; i < spawner.numberOfWaves; i++)
        {
            GUI.Label(new Rect(10, i * 40, 100, 20), "Wave " + i.ToString());

            int enemyIndex = 0;
            foreach (GameObject enemy in spawner.typeOfEnemies)
            {
                /*numberOfEnemies[i][enemyIndex] = EditorGUILayout.IntField(enemy.name, numberOfEnemies[i][enemyIndex]);*/
                enemyIndex++;
            }
        }

        GUI.EndScrollView();
    }
}
