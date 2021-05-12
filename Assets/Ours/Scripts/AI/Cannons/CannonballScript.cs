using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballScript : MonoBehaviour
{
    public Rigidbody2D m_rigidbody;
    public float speed = 3f;
    public Transform player;
    public float cannonballLife = 5f;
    public int cannonType = 0;
    public int hp = 1;
    private AICore core;

    // Start is called before the first frame update
    void Start()
    {
        core = new AICore(hp, cannonballLife);
        m_rigidbody = this.transform.GetComponent<Rigidbody2D>();
        if (cannonType == 1)
        {
            m_rigidbody.AddForce(Vector2.left * speed);
        }
        //Destroy(this.gameObject, cannonballLife );
    }

    // Update is called once per frame
    void Update()
    {
        core.elapseTime(Time.deltaTime);
        if (!core.isAlive()) Destroy(this.gameObject);
        else if (cannonType == 0)
        {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            
        }
        else if(cannonType == 2)
        {
            m_rigidbody.AddForce(Vector2.left * speed);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject, 0.1f);
        Debug.Log("Cannonball hit something");
    }
}
