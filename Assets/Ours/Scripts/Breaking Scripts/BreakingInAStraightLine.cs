using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingInAStraightLine : MonoBehaviour
{
    private bool startTimer = false;
    private float breakingTime = 0f;
    public float BREAKINGTIME = 2f;
    public Transform spawningObject;
    public Transform finalObject;
    private static int numTiles = 10;
    private float xOffset = 5f;
    private float yOffset = 2f;
    public int tilesNeeded = 10;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            breakingTime += Time.deltaTime;
            if (breakingTime >= BREAKINGTIME)
            {
                Destroy(this.gameObject);
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Player" && startTimer == false && numTiles>=0)
        {
            startTimer = true;
            Vector3 spawnposition = this.transform.position + new Vector3(xOffset, yOffset);
            numTiles--;
            if (numTiles > 0)
            {
                Instantiate(spawningObject, spawnposition, Quaternion.identity);
            }
            else if(numTiles == 0)
            {
                Instantiate(finalObject, spawnposition, Quaternion.identity);
                numTiles = tilesNeeded;
            }
            this.gameObject.GetComponent<Renderer>().material.color = new Color(233f / 255f, 0f, 0f);
        }
    }
}
