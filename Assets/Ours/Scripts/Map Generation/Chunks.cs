using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Chunks 
{
    //-2 = entrance
    //-1 = exit
    //0 = nothing
    //1 = grass block
    //2 = honey block
    //3 = dirt block
    //4
    
    public static float yOffset = 2.56f;
    public static float xOffset = 2.56f;
    
    public static int[,] chunk1 = new int[,] { {1,1,1,1},
                                               {3,3,0,-1},
                                               {0,0,0,1},
                                               {1,1,1,3} };
    public static int[,] chunk2 = new int[,] { {1,1,1,1,1,1},
                                               {3,0,0,0,3,3},
                                               {-2,0,0,0,0,3},
                                               {1,2,2,1,0,-1},
                                               {3,3,3,3,1,2 }};
    public static int[,] chunk3 = new int[,] {  {-2,0,1 },
                                                {1,0,-1 },
                                                {3,1,1 } };
    public static void initChunk1()
    {
    }
    public static int[,] generateRandomChunk(int sizeX, int sizeY, RandomHandler rnd, int[] ratio)
    {
        bool entranceExists = false;
        bool exitExists = false;
        int[,] chunk = new int[sizeY, sizeX];
        for (int y = sizeY - 1; y > -1; y--)
        {
            for (int x = 0; x < sizeX; x++)
            {
                int r = rnd.RandomNumber(100); 
                for(int i = 0; i < ratio.Length; i++)
                { 
                    r -= ratio[i]; 
                    if (r <= 0)
                    {
                        chunk[y, x] = i;
                        if(y + 1 < sizeY)
                        {
                            if (chunk[y + 1, x] == 1 || chunk[y + 1, x] == 2)
                            {
                                chunk[y, x] = 0;
                            }
                        }
                        break;
                    }
                } 
            }
        }
        return chunk;
    }
}
//column 1 = entrance, last column = exit, for now
//The needs to be connected pathways between the entrance and the exit
//dirt cannot be above grass or honey
// there must always be a floor that can be walked on, the level must be possible
//some blocks, like honey, are less likely to generate than grass