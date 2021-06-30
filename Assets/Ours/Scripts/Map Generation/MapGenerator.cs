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
    // Start is called before the first frame update
    void Start()
    {
        rnd = new RandomHandler(minSeed, maxSeed);
        
        seed = rnd.GetSeed();
        for (numOfBlocks = Mathf.Ceil(Mathf.Log10(seed)); numOfBlocks > 0; numOfBlocks--)
        {
            int blockType = rnd.RandomNumber(blocks.Length);
            Vector3 spawnposition = block.transform.position + new Vector3(xOffset, yOffset);
            block = Instantiate(blocks[blockType], spawnposition, Quaternion.identity);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
