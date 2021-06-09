using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileSpawner : MonoBehaviour
{
    public GameObject smileEnemy;
    public Transform spawnLocation;
    public AICore core;

    public float spawnTimer = 3f;
    public int spawnCap = 2;
    public int enemyAmount;
    public float detectionRadius = 5f;
    private bool spawning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawning)
        {
            Invoke("SpawnEnemy", spawnTimer);
            spawning = true;
        }
        
    }
    void SpawnEnemy()
    {
        if (AICore.spawnerAI < spawnCap)
        {
            Debug.Log("Summoned Enemy");
            Debug.Log("This is the number of AI: " + AICore.spawnerAI);
            GameObject spawnEnemy = Instantiate(smileEnemy, spawnLocation);
            spawnEnemy.GetComponent<EnemyAI>().spawn();
        }
        spawning = false;
    }
}
