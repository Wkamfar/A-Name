using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICore 
{
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

    public bool isAlive() { if (hitPoints == 0 || lifeElapsed >= lifespan) return false; return true; }
}
