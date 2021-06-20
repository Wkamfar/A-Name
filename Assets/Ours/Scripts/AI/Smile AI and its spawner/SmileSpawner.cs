using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileSpawner : MonoBehaviour
{
    public GameObject smileEnemy;
    public Transform spawnLocation;
    public AICore core;
    public Transform[] moveSpots;
    public float spawnTimer = 3f;
    public int spawnCap = 2;
    public int enemyAmount;
    public float detectionRadius = 5f;
    private bool spawning;
    public int totalSpawnAmount;
    private int totalSpawned;
    public Color killedColor;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("difficultyIncrease");
    }

    IEnumerator difficultyIncrease()
    {
        
        Debug.Log("difficultyIncrease : Before Difficulty Increase");
        for (int i = 0; spawnCap < 10; i++)
        {
            yield return new WaitForSeconds(3f);
            Debug.Log("difficultyIncrease : After Difficulty Increase");
            spawnCap++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!spawning)
        {
            Invoke("SpawnEnemy", spawnTimer);
            spawning = true;
        }
        if(totalSpawned >= totalSpawnAmount)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = killedColor;
            Destroy(this);
        }
    }
    void SpawnEnemy()
    {
        if (AICore.spawnerAI < spawnCap)
        {
            Debug.Log("SmileSpawner.SpawnEnemy(): Summoned Enemy");
            Debug.Log("SmileSpawner.SpawnEnemy(): Spawned Num = " + AICore.spawnerAI);
            Debug.Log("SmileSpawner.SpawnEnemy(): Spawn location = " + spawnLocation.position);
            GameObject spawnEnemy = Instantiate(smileEnemy, spawnLocation);
            spawnEnemy.transform.parent = null;
            totalSpawned++;
            spawnEnemy.GetComponent<EnemyAI>().spawn();
            spawnEnemy.GetComponent<EnemyAI>().canMove();
        }
        spawning = false;
    }
}
