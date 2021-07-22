using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunksHelper 
{
    private int ySize;
    private int xSize;
    private int[,] chunk;
    private int[] ratio;
    private RandomHandler rnd;
    private int startPoint;
    private int endPoint;
    public ChunksHelper(int sizeY, int sizeX, int[,] c, int[] r)
    {
        ySize = sizeY;
        xSize = sizeX;
        chunk = c;
        ratio = r;
        rnd = new RandomHandler();
        createEntrance();
        createExit();
        createPath();
    }
    public void createEntrance()
    {
        startPoint = rnd.RandomNumber(ySize);
        chunk[startPoint, 0] = -2;
        Debug.Log("ChunksHelper.CreateEntrance: the entrance was created at " + startPoint);
    }
    public void createExit()
    {
        endPoint = rnd.RandomNumber(ySize);
        chunk[endPoint, xSize - 1] = -1;
    }
    public void createPath()
    {
        bool reachedExit = false;
        int[] curnPoint = new int[2];
        curnPoint[0] = startPoint;
        int currentY = startPoint;
        int currentX = 0;
        while (reachedExit == false)
        {

            int xDir = rnd.RandomNumber(2);
            int yDir = rnd.RandomNumber(2);
            int dir = rnd.RandomNumber(2);

            if (dir == 0 )
            {
                if (currentY - 1 == -1)
                {
                    curnPoint[0]++;
                }
                else if (currentY + 1 == ySize)
                {
                    curnPoint[1]--;
                }
                else if(!(chunk[currentY - 1, currentX] == -10 || chunk[currentY + 1, currentX] == -10 || chunk[currentY - 1, currentX] == -2 || chunk[currentY + 1, currentX] == -2))
                    curnPoint[0] += yDir * 2 - 1;
                else if(chunk[currentY - 1, currentX] == -10 || chunk[currentY - 1, currentX] == -2)
                {
                    curnPoint[0]++;
                }
                else if (chunk[currentY + 1, currentX] == -10 || chunk[currentY + 1, currentX] == -2)
                {
                    curnPoint[0]--;
                }
            }
            else if (dir == 1)
            {
                curnPoint[1] += xDir;
            }           
            if (curnPoint[1] == xSize)
            {
                curnPoint[1]--;
            }
            if (curnPoint[0] == ySize - 1)
            {
                curnPoint[0]--;
            }
            else if (curnPoint[0] == -1)
            {
                curnPoint[0]++;
            }
            if (curnPoint[0] == endPoint && curnPoint[1] == xSize - 1)
            {
                break;
            }
            chunk[curnPoint[0], curnPoint[1]] = -10;
            currentY = curnPoint[0];
            currentX = curnPoint[1];
        }
    }
}
