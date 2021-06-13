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
        spawnSync += 1;
        core = new AICore(hp, ls);
        randSpotIndex = Random.Range(0, moveSpots.Length);
        Debug.Log("EnemyAI.Start(): number of spawned AI = " + core.getNumOfSpawnerAI());

        Debug.Log("EnemyAI.Start(): Spawn sync = " + spawnSync);
            
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnSync > 1)
        {
            core.spawn();
            spawnSync = 0;

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
        else 
            spawnSync++;
        Debug.Log("EnemyAI.spawn(): Spawn sync =  " + spawnSync);

    }
    public void killed()
    {
        core.takeDamage();
        if(!core.isAlive())
            Destroy(this.gameObject);
    }
} 
