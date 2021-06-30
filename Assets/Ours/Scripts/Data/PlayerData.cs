using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public int lives;
    public int coinCount;
    public int currentLevel;

    public PlayerData(int lives, int coinCount, int currentLevel)
    {
        this.lives = lives;
        this.coinCount = coinCount;
        this.currentLevel = currentLevel;
    }
}
