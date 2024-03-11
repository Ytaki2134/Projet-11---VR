using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Options : MonoBehaviour
{
    private Vector3 pos = new Vector3(0.316f, 1.7f, -2.665f);
    private Vector3 rotation = new Vector3(0.316f, 1.7f, -2.665f);
    private bool isopen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseOrOpenOption () 
    {
        if (!isopen)
        {
            gameObject.SetActive(true);
           // MoveToPositionOpen();
            // set active 
            // Move + Rotate
            // 
        }
        else
        {
            gameObject.SetActive(false);
            // Move + Rotate
            // set active 

        }
        isopen = !isopen;
    }
    private void MoveToPositionOpen()
    {

    }
}
