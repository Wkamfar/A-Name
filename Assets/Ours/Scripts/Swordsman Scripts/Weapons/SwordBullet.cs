using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBullet : MonoBehaviour
{
    public float lifetime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifetime);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "CannonAI")
        {
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "Stompable")
        {
            col.gameObject.SetActive(false);
            Destroy(col.gameObject);
            //add coins for killing this object
        }
        else if(col.gameObject.tag == "Slayable")
        {
            col.gameObject.SetActive(false);
            Destroy(col.gameObject);
        }
        Destroy(this.gameObject);
        
    }

}
