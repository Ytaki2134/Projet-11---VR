using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using Unity.VisualScripting.YamlDotNet.Core;
using System.Linq;
using UnityEditor.VersionControl;
using System.IO;

public class WaveEditor : EditorWindow
{   
    public Vector2 scrollPosition = Vector2.zero;

    WavesSO waves = null;

    List<int[]> enemies = new List<int[]>();

    [MenuItem("Waves/Waves Editor")]
    public static void ShowWindow() 
    { 
        WaveEditor window = GetWindow<WaveEditor>();
        window.titleContent = new GUIContent("Waves Editor");
        window.waves = AssetDatabase.LoadAssetAtPath<WavesSO>("Assets/waves.asset");
        window.enemies = window.waves.enemies.Select(i => i.Enemies).ToList();
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
        
        if (GUI.Button(new Rect(110, 10, 100, 30), "Remove Wave"))
            if (spawner.numberOfWaves > 0)
            {
                spawner.numberOfWaves--;
                spawner.numberOfEnemiesInWave = spawner.RemoveArrayLenght(spawner.numberOfEnemiesInWave);
                enemies.Remove(enemies.Last());
            }

        scrollPosition = GUI.BeginScrollView(new Rect(10, 40, 300, 400), scrollPosition, new Rect(0, 0, 220, spawner.typeOfEnemies.Length * 35 * spawner.numberOfWaves));

        for (int i = 0; i < spawner.numberOfWaves; i++)
        {
            GUI.Label(new Rect(20, i * spawner.typeOfEnemies.Length * 50, 100, 20), "Wave " + (i + 1));
            GUI.Label(new Rect(120, i * spawner.typeOfEnemies.Length * 50, 200, 20), "Total number of enemies : " + spawner.numberOfEnemiesInWave[i]);
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

        if (GUI.Button(new Rect(210, 10, 100, 30), "Create SO") && waves == null)
        {
            waves = ScriptableObject.CreateInstance<WavesSO>();
            waves.enemies = enemies.Select(i => new WavesSO.EnemyContainer() { Enemies = i }).ToList();
            AssetDatabase.CreateAsset(waves, "Assets/waves.asset");
        }
    }
}
