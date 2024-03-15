using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{
    public int maxNumberOfRocks;
    [HideInInspector] public int rockCount;

    private void Start()
    {
        rockCount = 0;
    }

    public void AddRock()
    {
        rockCount++;
    }

    public void RemoveRock()
    {
        rockCount--;
    }
}
