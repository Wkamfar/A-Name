using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject block;
    public GameObject[] blocks;
    public GameObject[] AI;
    public GameObject[] chunks;
    public GameObject flag;
    private RandomHandler rnd;
    public int minSeed;
    public int maxSeed;
    public float xOffset;
    public float yOffset;
    private int seed;
    private float numOfBlocks;
    private int direction;
    private int numOfEnemies;
    public float flagChance;
    public int minFlagDistance;
    public float chanceIncrease;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnposition = new Vector3(0, 0);
        rnd = new RandomHandler(minSeed, maxSeed);
        
        seed = rnd.GetSeed();
        for (numOfBlocks = Mathf.Ceil(Mathf.Log10(seed)); numOfBlocks > 0; numOfBlocks--)
        {
            int blockType = rnd.RandomNumber(blocks.Length);
            spawnposition = block.transform.position + new Vector3(xOffset, yOffset);
            block = Instantiate(blocks[blockType], spawnposition, Quaternion.identity);
        }
        
        spawnposition = generateChunk(Chunks.chunk1, spawnposition, true);
        spawnposition = generateChunk(Chunks.chunk2, spawnposition, false);
        spawnposition = generateChunk(Chunks.chunk3, spawnposition, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 generateChunk(int[,] chunk, Vector3 spawnposition, bool firstChunk)
    {
        Vector3 exitPoint = new Vector3(0,0);
        float xDisplacement = 0;
        if(!firstChunk)
            spawnposition = findEntrance(chunk, spawnposition);
        for (int y = chunk.GetLength(0) - 1; y > -1; y--)
        {
            //firstColumnBlock = block;
            for (int x = 0; x < chunk.GetLength(1); x++)
            {
                xDisplacement += Chunks.xOffset; 
                spawnposition += new Vector3(Chunks.xOffset, 0);
                int blockType = chunk[y, x] - 1;
                if(blockType == -1)
                {
                    //Debug.Log("MapGenerator: Generate Chunk: Before Continue");
                    continue;
                }
                else if(blockType == -2)
                {
                    exitPoint = spawnposition;
                    continue;
                }
                else if(blockType == -3)
                {
                    continue;
                }
                block = Instantiate(blocks[blockType], spawnposition, Quaternion.identity);
            }
            spawnposition += new Vector3(0 - xDisplacement, Chunks.yOffset);
            xDisplacement = 0;
            //block = firstColumnBlock;
        }
        return exitPoint;
    }
    private Vector3 findEntrance(int[,] chunk, Vector3 spawnposition)
    {
        for (int y = chunk.GetLength(0) - 1; y > -1; y--)
        {
            if(chunk[y,0] == -2)
            {
                spawnposition -= new Vector3(0, (chunk.GetLength(0) -1 - y) * Chunks.yOffset);
            }
        }
        return spawnposition;
    }

}
