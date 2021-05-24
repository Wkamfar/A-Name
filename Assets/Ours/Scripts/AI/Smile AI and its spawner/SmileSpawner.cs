using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmileSpawner : MonoBehaviour
{
    public GameObject smileEnemy;
    public Transform spawnLocation;

    public float spawnTimer = 3f;
    public int spawnCap = 2;
    public int enemyAmount;
    public float detectionRadius = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("SpawnEnemy", spawnTimer);
    }
    void SpawnEnemy()
    {
        if (enemyAmount < 2)
        {
            Instantiate(smileEnemy, spawnLocation);
            enemyAmount++;
        }
        else { return; }
    }
}
