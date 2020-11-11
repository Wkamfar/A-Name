using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CoinAI : MonoBehaviour
{
    static public int coinCount;
    public Text coinTextBox;
    public int timeOut;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(timeOut > 0)
        {
            timeOut--;
        }
        //coinTextBox.text = coinCount.ToString();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin") && timeOut<=0)
        {
            timeOut = 3;
            col.gameObject.SetActive(false);
            Destroy(col.gameObject);
            coinCount++;
            coinTextBox.text = "Points: " + coinCount.ToString();
        }
        else if (col.CompareTag("Stompable") && timeOut <= 0)
        {
            timeOut = 3;
            col.gameObject.SetActive(false);
            Destroy(col.gameObject);
            coinCount+=3;
            coinTextBox.text = "Points: " + coinCount.ToString();
            //transform.position = Vector2.MoveTowards(transform.position, moveSpots[randSpotIndex].position, speed * Time.deltaTime);
            //m_rigidbody.AddForce(Vector2.up * 10);
           
            Debug.Log("Hitting Stompable object");
        }
        else if(col.CompareTag("Flag") && timeOut <= 0){
            Debug.Log("Trying to load L2");
            SceneManager.LoadScene("L2");
        }
    }
}
