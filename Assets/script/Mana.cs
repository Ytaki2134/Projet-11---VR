using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] private int maxMana;
    [SerializeField] private int gainMana;
    [SerializeField] private float delay;
    [SerializeField] private int mana;
    private float lastTime = 0;
    
    // Start is called before the first frame update
    void Start(){ mana = maxMana;}
    public void AddMana(int addmana){ mana += addmana; }
    public int GetMana() { return mana; }

    // Update is called once per frame
    void Update()
    {
        lastTime += Time.deltaTime;
        if (lastTime > delay && mana <maxMana )
        {
            lastTime = 0;
            AddMana(gainMana);
        }
    }

    //Verify if the cost of a spell is minor than the mana of the player ;
    public bool CanUseMana(int cost)
    {
        if (mana - cost < 0)
            return false;
        else 
            return true;
    }

    //
    public void UseMana(int cost)
    {
        if(CanUseMana(cost))
            mana -= cost;
    }

}
