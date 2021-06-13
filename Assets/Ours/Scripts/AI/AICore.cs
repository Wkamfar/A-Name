using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICore 
{
    //Booleans
    private bool exist;
    private bool partOfSpawner;
    //Integer Variables
    public static int numOfAI = 0;
    private int hitPoints;
    public static int spawnerAI = 0;
    //Float Variables
    private float lifeElapsed = 0f;
    private float lifespan;
    //Functions
    public AICore(int hp, float ls)
    {
        lifespan = ls;
        hitPoints = hp;
        lifeElapsed = 0f;
        numOfAI++;
        exist = true;
    }
    public void spawn()
    {
        spawnerAI++;
        partOfSpawner = true;
        Debug.Log("AICore.spawn()");
    }
    public AICore()
    {
        
    }
    public void elapseTime(float timeChange)
    {
        lifeElapsed += timeChange;
        //if (lifeElapsed > lifespan)
            //this.died();
    }
    
    public void takeDamage()
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            hitPoints = 0;
            this.died();
        }
    }
    public int getNumberOfAI()
    {
        return numOfAI;
    }
    public int getNumOfSpawnerAI()
    {
        return spawnerAI;
    }
    private void died()
    {
        Debug.Log("AICore.died(): exist = " + exist);
        if (exist)
        {
            Debug.Log("AICore.died(): PartOfSpawner = " + partOfSpawner);
            numOfAI--;
            exist = false;
            if (partOfSpawner)
            {
                spawnerAI--;
            }
        }
        
    }
    
    public bool isAlive() { if (hitPoints == 0 || lifeElapsed >= lifespan) return false; return true; }
}
