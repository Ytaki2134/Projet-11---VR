using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyStrenghtRail : MonoBehaviour
{


    [SerializeField] private float StrenghtRail;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<RockBehaviour>())
        {
            other.gameObject.GetComponent<RockBehaviour>()._strength = StrenghtRail;
        }
    }
}
