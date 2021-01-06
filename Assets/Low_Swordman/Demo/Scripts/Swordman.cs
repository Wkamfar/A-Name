using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Swordman : PlayerController
{
    public float breakingTime = 2f;
    public float dashSpeed = 500f;
    private float DASHCOOLDOWN = 1f;
    public float dashCooldown = 1f;
    public float defaultMoveSpeed = 6f;
    public float currentMoveSpeed = 6f;
    public float rightBounceSpeed = 1000f;
    public float bounceSpeed = 1000f;
    private bool permaDeath = false;
    public GameObject defaultUI;
    public GameObject deathMenu;
    public int maxLives = 3;
    static public int lives = 3;
    static public int coinCount;
    public int sameCoinCount;
    public string levelName = "Demo";
    public int coinSave = 0;
    public int deathPenalty = 2;
    //public Text coinTextBox;
    public TextMeshProUGUI coinTextBox;
    public int timeOut;
    public int minHeight = -10;
    public Transform checkpoint;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public float REBORNTIME = 3f;
    private float rebornTime = 0f;
    public Image damaged;
    public float GRAVITYTIMER = 3f;
    private float gravityTimer = 0f;
    //heart1.enabled = false;
    public void Start()
    {
        //disableDeathMenu();
        coinSave = coinCount;
        m_CapsulleCollider  = this.transform.GetComponent<CapsuleCollider2D>();
        m_Anim = this.transform.Find("model").GetComponent<Animator>();
        m_rigidbody = this.transform.GetComponent<Rigidbody2D>();
        coinTextBox.text = "Points: " + coinCount.ToString();
        updateHeartsUI ();
        disableDeathMenu();
    }
    public void StartFirstLevel()
    {
        Debug.Log("First Level Lmao");
        Reset();
        SceneManager.LoadScene(1);
    }
    private void Reset()
    {
        lives = 3;
        coinCount = 0;
    }
    public void StartMainMenu()
    {
        Debug.Log("Start Menu Lmao");
        Reset();
        SceneManager.LoadScene(0);
        
    }
    private void updateHeartsUI()
    {
        if (lives <= 2)
        {
            heart3.enabled = false;
        }
        if (lives <= 1)
        {
            heart2.enabled = false;
        }
        if (lives <= 0)
        {
            heart1.enabled = false;
            enableDeathMenu();
            permaDeath = true;
        }
    }
    private void loseHeart()
    {
        lives--;
        damaged.enabled = true;
        updateHeartsUI();
        m_Anim.Play("Die");
        Debug.Log("Lost a Heart");
        currentMoveSpeed = defaultMoveSpeed;
    }
    private void enableDeathMenu()
    {
        
        /*foreach (Transform child in deathMenu)
        {
            child.gameObject.SetActive (true);
        }*/
        deathMenu.SetActive(true);
        defaultUI.SetActive(false);
    }
    private void disableDeathMenu()
    {

        /* foreach (Transform child in deathMenu)
         {
             child.gameObject.SetActive(false);
         }
         */
        deathMenu.SetActive(false);
        defaultUI.SetActive(true);
    }
    private void respawn()
    {
        //enableDeathMenu();
        //Perma Death after 0 with loss menu
        loseHeart();
        Debug.Log("Respawning");
        this.transform.position = checkpoint.position;
        
        coinCount = 0;
        coinCount += coinSave;
        coinCount -= deathPenalty;
        if (coinCount < 0)
        {
            coinCount = 0;
        }
        if (lives > 0)
        {
            SceneManager.LoadScene(levelName);
        }
    }

    private void Update()
    {
        if (timeOut > 0)
        {
            timeOut--;
        }
        if (rebornTime > 0)
        {
            rebornTime-=Time.deltaTime;
           
        }
        else
        {
            damaged.enabled = false;

        }
        if (gravityTimer > 0)
        {
            gravityTimer -= Time.deltaTime;
            m_rigidbody.gravityScale = 0;
        }
        else
        {
            m_rigidbody.gravityScale = 3;
        }
        if (dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
        }
        
        checkInput();

        if (m_rigidbody.velocity.magnitude > 30)
        {
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x - 0.1f, m_rigidbody.velocity.y - 0.1f);

        }
        if (this.transform.position.y < minHeight)
        {
            respawn();
        }



    }

    public void checkInput()
    {

        if (permaDeath == true)  
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.S))  //아래 버튼 눌렀을때. 
        {

            IsSit = true;
            m_Anim.Play("Sit");


        }
        else if (Input.GetKeyUp(KeyCode.S))
        {

            m_Anim.Play("Idle");
            IsSit = false;

        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <0)
        {
            m_rigidbody.AddForce(Vector2.right * dashSpeed);
            dashCooldown = DASHCOOLDOWN;
        }

        // sit나 die일때 애니메이션이 돌때는 다른 애니메이션이 되지 않게 한다. 
        if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Sit") || m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentJumpCount < JumpCount)  // 0 , 1
                {
                    DownJump();
                }
            }

            return;
        }


        m_MoveX = Input.GetAxis("Horizontal");


   
        GroundCheckUpdate();


        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {


                m_Anim.Play("Attack");
            }
            else
            {

                if (m_MoveX == 0)
                {
                    if (!OnceJumpRayCheck)
                        m_Anim.Play("Idle");

                }
                else
                {

                    m_Anim.Play("Run");
                }

            }
        }


        if (Input.GetKey(KeyCode.Alpha1))
        {
            m_Anim.Play("Die");

        }

        // 기타 이동 인풋.

        if (Input.GetKey(KeyCode.D))
        {

            if (isGrounded)  // 땅바닥에 있었을때. 
            {



                if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    return;

                transform.transform.Translate(Vector2.right* m_MoveX * MoveSpeed * Time.deltaTime);



            }
            else
            {

                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));

            }




            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;

            if (!Input.GetKey(KeyCode.A))
                Filp(false);


        }
        else if (Input.GetKey(KeyCode.A))
        {


            if (isGrounded)  // 땅바닥에 있었을때. 
            {



                if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    return;


                transform.transform.Translate(Vector2.right * m_MoveX * MoveSpeed * Time.deltaTime);

            }
            else
            {

                transform.transform.Translate(new Vector3(m_MoveX * MoveSpeed * Time.deltaTime, 0, 0));

            }


            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;

            if (!Input.GetKey(KeyCode.D))
                Filp(true);


        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;


            if (currentJumpCount < JumpCount)  // 0 , 1
            {

                if (!IsSit)
                {
                    prefromJump();


                }
                else
                {
                    DownJump();

                }

            }


        }



    }


  


    protected override void LandingEvent()
    {


        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Run") && !m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            m_Anim.Play("Idle");

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin") && timeOut <= 0)
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
            coinCount += 3;
            coinTextBox.text = "Points: " + coinCount.ToString();
            //transform.position = Vector2.MoveTowards(transform.position, moveSpots[randSpotIndex].position, speed * Time.deltaTime);
            //m_rigidbody.AddForce(Vector2.up * 10);

            Debug.Log("Hitting Stompable object");
        }
        else if (col.CompareTag("Speed") && timeOut <= 0)
        {
            timeOut = 3;
            col.gameObject.SetActive(false);
            Destroy(col.gameObject);
            currentMoveSpeed = currentMoveSpeed * 2;
            MoveSpeed = currentMoveSpeed;
        }
        else if (col.CompareTag("ZeroGravity") && timeOut <= 0)
        {
            timeOut = 3;
            col.gameObject.SetActive(false);
            Destroy(col.gameObject);
            gravityTimer = GRAVITYTIMER;

        }
        else if (col.CompareTag("Invinsible") && timeOut <= 0)
        {
            timeOut = 3;
            col.gameObject.SetActive(false);
            Destroy(col.gameObject);
            rebornTime = REBORNTIME;
            damaged.enabled = true;

        }
        else if (col.CompareTag("heartPowerUp") && timeOut <= 0)
        {
            timeOut = 3;
            col.gameObject.SetActive(false);
            Destroy(col.gameObject);
            lives++;
            if (lives > maxLives)
            {
                lives = maxLives;
            }
            else if(lives == 2)
            {
                heart2.enabled = true;
            }
            else if(lives == 3)
            {
                heart3.enabled = true;
            }

        }
        else if (col.CompareTag("Flag") && timeOut <= 0)
        {
            
            Debug.Log("Trying tqo load L2");
            SceneManager.LoadScene("L2");
            levelName = "L2";
            
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Deadly" && timeOut <= 0)
        {
           // m_Anim.Play("Die");
            //lives--;
        }
        else if (col.gameObject.tag == "Bouncy")
        {
            m_rigidbody.AddForce(Vector2.up * bounceSpeed);

        }
        else if (col.gameObject.tag == "rightBouncy")
        {
            m_rigidbody.AddForce(Vector2.right * rightBounceSpeed);

        }
        else if (col.gameObject.tag == "bothBounce")
        {
            m_rigidbody.AddForce(Vector2.up * bounceSpeed);
            m_rigidbody.AddForce(Vector2.right * rightBounceSpeed);
        }
        
    }
    void OnCollisionStay2D (Collision2D col)
    {
        if (col.gameObject.tag == "Deadly" && timeOut <= 0 && rebornTime <= 0)
        {
            rebornTime = REBORNTIME;
            //m_Anim.Play("Die");
            Debug.Log("Deadly Object");
            Debug.Log(rebornTime);
            loseHeart();
            
        }
        else if (col.gameObject.tag == "Sticky")
        {
            currentJumpCount = 2;
            MoveSpeed = 2f;
            Debug.Log(currentJumpCount);
           
        }
        else if (col.gameObject.tag == "Slide")
        {

            m_rigidbody.angularDrag = 0;
        }
        else
        {
            MoveSpeed = currentMoveSpeed;
        }
    }

}
