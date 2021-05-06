using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalClone : MonoBehaviour
{
    public GameObject player;
    public float speed = 4f;
    public int verticalEnemyLives = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Targetpos = new Vector3(this.transform.position.x, player.transform.position.y, 5);
        transform.position = Vector2.MoveTowards(transform.position, Targetpos, speed * Time.deltaTime);
        //Checking Health
        if (verticalEnemyLives <= 0)
        {
            this.gameObject.SetActive(false);
            Destroy(this);
        }
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "SwordBullet")
        {
            verticalEnemyLives--;
            Debug.Log(verticalEnemyLives);
        }
    }
    void OnTriggerStay2D (Collider2D col)
    {
        if (col.CompareTag("AimZone"))
        {
            Debug.Log("Aiming!");
        }
    }
}
