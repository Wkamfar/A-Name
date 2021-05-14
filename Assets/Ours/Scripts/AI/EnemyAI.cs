using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int speed;
    public Transform[] moveSpots;
    private int randSpotIndex;
    private int hp = 1;
    public float ls;
    private AICore core;
    // Start is called before the first frame update
    void Start()
    {
        core = new AICore(hp, ls);
        randSpotIndex = Random.Range(0, moveSpots.Length);   
    }

    // Update is called once per frame
    void Update()
    {
        core.elapseTime(Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randSpotIndex].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position,moveSpots[randSpotIndex].position)<0.1f)
        {
            randSpotIndex = Random.Range(0, moveSpots.Length);
        }
    }
}
