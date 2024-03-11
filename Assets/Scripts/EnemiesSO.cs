using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemies")]
public class EnemiesSO : ScriptableObject
{
    public List<int[]> enemies;
}
