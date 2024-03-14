using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject text; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SeeWatch() 
    {
        transform.localScale = new Vector3(transform.localScale.x * 2,transform.localScale.y, transform.localScale.z * 2.5f);
        text.SetActive(true);
    }
    
    public void UnSeeWatch() 
    {
        text.SetActive(false);
        transform.localScale = new Vector3(transform.localScale.x / 2,transform.localScale.y, transform.localScale.z / 2.5f);
    }
}
