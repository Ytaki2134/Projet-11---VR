using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockEnter : MonoBehaviour
{
    [SerializeField] private GameObject Watch;
    [SerializeField] private GameObject Rock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Rock)
        {
            /*case (Watch.GetComponent<TransformRockXithMagic>().GetChoice()):



            default*/
            switch(Watch.GetComponent<TransformRockXithMagic>().GetChoice() )
            {
                case 0:
                    other.gameObject = Watch.GetComponent<TransformRockXithMagic>().GetNormalRock();
                    break;

                case 1:
                    break;
                
                case 2:
                    break;
                    
                case 3:
                    break;

                    
                default:
                    break;
            }
            

        }
    }
}
