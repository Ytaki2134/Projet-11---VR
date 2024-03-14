using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class FireObject : MonoBehaviour
{

    public float strenght = 1000;
    public bool Activate;
    public int destroyObject = -20;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y< destroyObject && Activate)
            Destroy(gameObject);
    }

    public void Fire()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        Debug.Log(transform.rotation);
        if(body.isKinematic)
        {
            body.isKinematic = false;
            GetComponent<XRGrabInteractable>().enabled = false;
            body.AddForce( transform.forward * -strenght);
            GetComponent<XRGrabInteractable>().enabled = true;
        }
    }
}
