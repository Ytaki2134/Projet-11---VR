using UnityEngine;
using UnityEditor;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.Rendering;

public class WaveEditor : EditorWindow
{   
    public Vector2 scrollPosition = Vector2.zero;
    public List<int[]> enemies;

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
        if (enemies == null)
        {
            enemies = new List<int[]>();
        }
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


        spawner.enemies = enemies;
        GUI.EndScrollView();
    }

    /*public static void CreateMyAsset(List<int[]> enemies)
    {
        EnemiesSO asset = ScriptableObject.CreateInstance<EnemiesSO>();
        asset.enemies = enemies;

        AssetDatabase.CreateAsset(asset, "Assets/Enemies.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }*/
}
