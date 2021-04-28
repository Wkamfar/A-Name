using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public static CameraController Instance;

    public GameObject Target;
    private float Smoothvalue = 4f;
    public float PosY = 1;
    public float speed;
    public Transform[] moveSpots;
    private int index = 0;
    public float duration = 4f;
    private float introSpeed = 0.2f;
    static private float elapsed = 0f;

    // Use this for initialization
    public Coroutine my_co;

    void Start()
    {
        if (elapsed > duration)
        {
            Vector3 Targetpos = new Vector3(Target.transform.position.x, Target.transform.position.y + PosY, -100);
            transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * 100);
        }
        else
        {
            Smoothvalue = introSpeed;
        }
         
    }


    void Update()
    {
       /* while (index < moveSpots.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[index].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[index].position) < 0.1f)
            {
                index += 1;
            }
        }*/
        Vector3 Targetpos = new Vector3(Target.transform.position.x, Target.transform.position.y + PosY, -100);
        transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * Smoothvalue);
        if(elapsed > duration && Smoothvalue < 4)
        {
            Smoothvalue += Time.deltaTime;
        }
        elapsed += Time.deltaTime;

    }
    void OnTriggerEnter(Collider2D col)
    {
        if(col.gameObject.tag == "Flag")
        {
            elapsed = 0;
        }
    }


}
