using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Waves", order = 1)]
public class WavesSO : ScriptableObject
{
    [Serializable]
    public class EnemyContainer
    {
        [SerializeField] int[] _enemies;

        public int[] Enemies { get => _enemies; set => _enemies = value; }
    }



    public List<EnemyContainer> enemies;
}
