using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRockXithMagic : MonoBehaviour
{

    [SerializeField] private GameObject NormalRock;
    [SerializeField] private GameObject FireRock;
    [SerializeField] private GameObject IceRock;
    [SerializeField] private GameObject ThunderRock;

    private int choice = 0;

    private bool fireGem = false;
    private bool iceGem = false;
    private bool thunderGem = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ToNormalRock()
    {
        choice = 0;
    }
    public void ToFireRock()
    {
        if(fireGem) choice = 1;
    }
    public void ToIceRock()
    {
        if(iceGem) choice = 2;
    }
    public void ToThunderRock()
    {
        if(thunderGem)  choice = 3;
    }

    public void GetFireGem() { fireGem = !fireGem; }
    public void GetIceGem() { iceGem = !iceGem; }
    public void GetThunderGem() { thunderGem= !thunderGem; }

    public int GetChoice() { return choice; }


    public GameObject GetNormalRock() { return NormalRock; }
    public GameObject GetFireRock() { return FireRock; }
    public GameObject GetIceRock() { return IceRock; }
    public GameObject GetThunderRock() { return ThunderRock; }
}
