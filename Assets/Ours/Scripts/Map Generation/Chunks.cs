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
}
