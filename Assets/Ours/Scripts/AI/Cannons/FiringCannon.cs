using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringCannon : MonoBehaviour
{
    public GameObject cannonball;
    public float timeSpawn;
    private float timer;
    public float xOffset = -.05f;
    public float yOffset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > timeSpawn)
        {
            timer = 0;
            Vector3 spawnposition = this.transform.position + new Vector3(xOffset, yOffset);
            Instantiate(cannonball, spawnposition, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
        }
        timer += Time.deltaTime;
    }
}
