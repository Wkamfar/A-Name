using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingInAPattern : MonoBehaviour
{
    private bool startTimer = false;
    private float breakingTime = 0f;
    public float BREAKINGTIME = 2f;
    public Transform spawningObject;
    public Transform finalObject;
    public static int numTiles = 10;
    public float xOffset = 10f;
    public float yOffset = 0f;
    public Transform breakingParticle;
    public Transform player;
    public static int tilesNeeded = 10;
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
            Instantiate(breakingParticle, spawnposition - new Vector3(0, 0), Quaternion.identity);
            if (numTiles > 0)
            {
                Instantiate(spawningObject, spawnposition, Quaternion.identity);
            }
            else if(numTiles == 0)
            {
                Instantiate(finalObject, spawnposition, Quaternion.identity);
                
            }
            this.gameObject.GetComponent<Renderer>().material.color = new Color(233f / 255f, 0f, 0f);
        }
    }
}
