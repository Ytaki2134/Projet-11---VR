using UnityEngine;
using UnityEditor;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

public class WaveEditor : EditorWindow
{   
    public Vector2 scrollPosition = Vector2.zero;/*
    public List<int[]> enemies  = new List<int[]> { };*/

    //private static WaveEditor instance = null;
    //public static WaveEditor Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //            instance = (WaveEditor)FindObjectOfType(typeof(WaveEditor));
    //        return instance;
    //    }
    //}

    [MenuItem("Waves/Waves Editor")]
    public static void ShowWindow() 
    { 
        WaveEditor window = GetWindow<WaveEditor>();
        window.titleContent = new GUIContent("Waves Editor");
    }

    public void OnGUI()
    {
        EnemySpawner spawner = GameObject.FindWithTag("Spawner").GetComponent<EnemySpawner>();
        //Debug.Log(spawner);

        if (GUI.Button(new Rect(10, 10, 100, 30), "Add Wave"))
        {
            //if (spawner.enemies == null)
            //{
            //    spawner.enemies = new List<int[]>();
            //}
            spawner.numberOfWaves++;
            spawner.numberOfEnemiesInWave = spawner.AddArrayLenght(spawner.numberOfEnemiesInWave);
            spawner.enemies.Add(new int[spawner.typeOfEnemies.Length]);
            Debug.Log(spawner.enemies.Count);
        }
        
        if (GUI.Button(new Rect(120, 10, 100, 30), "Remove Wave"))
            if (spawner.numberOfWaves > 0)
            {
                spawner.numberOfWaves--;
                spawner.numberOfEnemiesInWave = spawner.RemoveArrayLenght(spawner.numberOfEnemiesInWave);
                spawner.enemies.Remove(spawner.enemies.Last());
            }

        scrollPosition = GUI.BeginScrollView(new Rect(10, 40, 300, 400), scrollPosition, new Rect(0, 0, 220, spawner.typeOfEnemies.Length * 35 * spawner.numberOfWaves));

        for (int i = 0; i < spawner.numberOfWaves; i++)
        {
            spawner.numberOfEnemiesInWave[i] = 0;

            
            GUILayout.Space(20);
            for (int j = 0; j < spawner.typeOfEnemies.Length; j++)
            {
                /*spawner.enemies[i][j] = EditorGUILayout.IntSlider(spawner.typeOfEnemies[j].name, spawner.enemies[i][j], 0, 40);
                spawner.numberOfEnemiesInWave[i] += spawner.enemies[i][j];*/
            }
            GUILayout.Space(10);

            GUI.Label(new Rect(20, i * spawner.typeOfEnemies.Length * 35, 100, 20), "Wave " + (i + 1));
            GUI.Label(new Rect(120, i * spawner.typeOfEnemies.Length * 35, 200, 20), "Total number of enemies : " + spawner.numberOfEnemiesInWave[i]);
        }

        GUI.EndScrollView();

        /*spawner.enemies = enemies;*/
    }
}
