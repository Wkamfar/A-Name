using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballScript : MonoBehaviour
{
    public float speed = 3f;
    public Transform player;
    public float cannonballLife = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, cannonballLife );
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject, 0.1f);
        Debug.Log("Cannonball hit something");
    }
}
