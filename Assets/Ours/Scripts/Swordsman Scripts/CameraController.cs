using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public static CameraController Instance;

    public GameObject Target;
    public int Smoothvalue =2;
    public float PosY = 1;
    public float speed;
    public Transform[] moveSpots;
    private int index = 0;

    // Use this for initialization
    public Coroutine my_co;

    void Start()
    {
        
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



    }



}
