using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using Unity.VisualScripting.YamlDotNet.Core;
using System.Linq;

public class WaveEditor : EditorWindow
{   
    public Vector2 scrollPosition = Vector2.zero;

    List<int[]> enemies = new List<int[]> { };

    [MenuItem("Waves/Waves Editor")]
    public static void ShowWindow() 
    { 
        WaveEditor window = GetWindow<WaveEditor>();
        window.titleContent = new GUIContent("Waves Editor");
    }

    public void OnGUI()
    {
        EnemySpawner spawner = GameObject.FindWithTag("Spawner").GetComponent<EnemySpawner>();

        if (GUI.Button(new Rect(10, 10, 100, 30), "Add Wave"))
        {
            spawner.numberOfWaves++;
            spawner.numberOfEnemiesInWave = spawner.AddArrayLenght(spawner.numberOfEnemiesInWave);
            enemies.Add(new int[spawner.typeOfEnemies.Length]);
        }
        
        if (GUI.Button(new Rect(120, 10, 100, 30), "Remove Wave"))
            if (spawner.numberOfWaves > 0)
            {
                spawner.numberOfWaves--;
                spawner.numberOfEnemiesInWave = spawner.RemoveArrayLenght(spawner.numberOfEnemiesInWave);
                enemies.Remove(enemies.Last());
            }

        scrollPosition = GUI.BeginScrollView(new Rect(10, 40, 300, 400), scrollPosition, new Rect(0, 0, 220, spawner.typeOfEnemies.Length * 35 * spawner.numberOfWaves));

        for (int i = 0; i < spawner.numberOfWaves; i++)
        {
            GUI.Label(new Rect(20, i * spawner.typeOfEnemies.Length * 35, 100, 20), "Wave " + (i + 1));
            GUI.Label(new Rect(120, i * spawner.typeOfEnemies.Length * 35, 200, 20), "Total number of enemies : " + spawner.numberOfEnemiesInWave[i]);
            GUILayout.Space(20);

            spawner.numberOfEnemiesInWave[i] = 0;
            for (int j = 0; j < spawner.typeOfEnemies.Length; j++)
            {
                enemies[i][j] = EditorGUILayout.IntSlider(spawner.typeOfEnemies[j].name, enemies[i][j], 0, 40);
                spawner.numberOfEnemiesInWave[i] += enemies[i][j];
            }
            GUILayout.Space(10);
        }

        GUI.EndScrollView();
    }
}
