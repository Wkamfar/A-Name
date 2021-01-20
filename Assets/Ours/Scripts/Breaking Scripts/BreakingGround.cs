using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingGround : MonoBehaviour
{
    private bool startTimer = false;
    private float breakingTime = 0f;
    public float BREAKINGTIME = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            breakingTime += Time.deltaTime;
            if(breakingTime >= BREAKINGTIME)
            {
                Destroy(this.gameObject);
            }
        }
    
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" )
        {
            startTimer = true;
            this.gameObject.GetComponent<Renderer>().material.color = new Color(233f / 255f, 0f, 0f);
        }
    }
}
