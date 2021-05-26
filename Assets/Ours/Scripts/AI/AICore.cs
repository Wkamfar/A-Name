using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICore 
{
    //Booleans
    private bool exist;
    //Integer Variables
    private static int numOfAI = 0;
    private int hitPoints;
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

    public void elapseTime(float timeChange)
    {
        lifeElapsed += timeChange;
    }
    
    public void takeDamage()
    {
        hitPoints--;
        if (hitPoints < 0)
        {
            hitPoints = 0;
        }
    }
    public int getNumberOfAI()
    {
        return numOfAI;
    }
    public void died()
    {
        if (!this.isAlive() && exist)
        {
            numOfAI--;
            exist = false;
        }
    }
    public bool isAlive() { if (hitPoints == 0 || lifeElapsed >= lifespan) return false; return true; }
}
