using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    private float timer = 0f;
    private int rotation = 360;
    public float speed = 0.00001f;
    public float x = 0;
    public float y = 0.25f;
    public float z = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= speed) 
        {
            transform.Rotate(x, y, z);
            timer = 0;
        }
            
    }
}
