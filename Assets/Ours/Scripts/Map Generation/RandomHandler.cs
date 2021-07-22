using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHandler 
{
    private static int seed;
    private int minSeed;
    private int maxSeed;
    private static bool isSeedGenerated = false;
    public RandomHandler()
    {
        this.GenerateSeed();
        Debug.Log("RandomHandler.RandomHandler: 1");
    }
    public RandomHandler(int min, int max)
    {
        Debug.Log("RandomHandler.RandomHandler: 2");
        minSeed = min;
        maxSeed = max;
        start();
    }
    public void GenerateSeed()
    {
        if (isSeedGenerated)
            return;
        seed = Random.Range(minSeed, maxSeed);
        isSeedGenerated = true;
    }
    public int RandomNumber(int max)
    {
        return Random.Range(0, max);
    }
    public int GetSeed()
    {
        return seed;
    }
    private void start()
    {
        this.GenerateSeed();
        Random.InitState(seed);
        Debug.Log("RandomHandler.start: 3");
    }
    ~RandomHandler()
    {
        Debug.Log("RandomHandler.Deconstructor: is out, peace");
    }
}
