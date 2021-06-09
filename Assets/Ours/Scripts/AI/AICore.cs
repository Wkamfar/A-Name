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
        if (hitPoints < 0)
        {
            hitPoints = 0;
            this.died();
        }
    }
    public int getNumberOfAI()
    {
        return numOfAI;
    }
    private void died()
    {
        if (exist)
        {
            numOfAI--;
            exist = false;
            if (partOfSpawner)
            {
                spawnerAI--;
            }
        }
        
    }
    public void spawn()
    {
        spawnerAI++;
        partOfSpawner = true;
        Debug.Log("spawn Function was called");
    }
    public bool isAlive() { if (hitPoints == 0 || lifeElapsed >= lifespan) return false; return true; }
}
