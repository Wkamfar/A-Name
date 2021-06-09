using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int speed;
    private int spawnSync;
    public Transform[] moveSpots;
    private int randSpotIndex;
    private int hp = 1;
    public float ls;
    private AICore core;
    // Start is called before the first frame update
    void Start()
    { // Obama was here
        core = new AICore(hp, ls);
        spawnSync = 1;
        randSpotIndex = Random.Range(0, moveSpots.Length);
        Debug.Log("Smile enemy, AI spawn, number of AI = " + core.getNumberOfAI());

        Debug.Log("Spawn sync in start function is equal to " + spawnSync);
            
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnSync == 2)
        {
            core.spawn();
            spawnSync = 3;

        }
        core.elapseTime(Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randSpotIndex].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position,moveSpots[randSpotIndex].position)<0.1f)
        {
            randSpotIndex = Random.Range(0, moveSpots.Length);
        }
    }
    public void spawn()
    {
        if(spawnSync == 1)
            core.spawn();
        spawnSync = 2;
        Debug.Log("Spawn sync in the spawn function is equal to " + spawnSync);

    }
} 
