﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAI : MonoBehaviour
{
    public int speed;
    public Transform[] moveSpots;
    private int randSpotIndex;
    // Start is called before the first frame update
    void Start()
    {
        randSpotIndex = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randSpotIndex].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[randSpotIndex].position) < 0.1f)
        {
            randSpotIndex = Random.Range(0, moveSpots.Length);
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.parent = transform;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.parent = null;
        }
    }
}