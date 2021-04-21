using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SwordsmanClone : PlayerController
{

    
    //Weapons
    public GameObject swordBullet;
    public float swordSpeed = 500f;
    //Direction
    private bool swordsmanFaceRight = false;
    //Power Ups
    public float GRAVITYTIMER = 3f;
    private float gravityTimer = 0f;
    //Abilities
    public float dashSpeed = 500f;
    private float DASHCOOLDOWN = 1f;
    public float dashCooldown = 1f;
    //Launchers
    public float rightBounceSpeed = 1000f;
    public float bounceSpeed = 1000f;
    //Life and Death Variables
    public float REBORNTIME = 3f;
    private float rebornTime = 0f;
    public int minHeight = -10;
    public int timeOut;
    private bool permaDeath = false;
    //Player Move Speed
    public float defaultMoveSpeed = 6f;
    public float currentMoveSpeed = 6f;
    //AI
    public float enemyBounce = 500f;
    //Others
    public float breakingTime = 2f;
    public void Start()
    {
        //Initializing Variables
        m_CapsulleCollider = this.transform.GetComponent<CapsuleCollider2D>();
        m_Anim = this.transform.Find("model").GetComponent<Animator>();
        m_rigidbody = this.transform.GetComponent<Rigidbody2D>();
    }

    //For The Timers
    private void updateTimers()
    {
       
        if (timeOut > 0)
        {
            timeOut--;
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
    }
    //Come Back Later, Haven't done anything yet
    private void Update()
    {
        updateTimers();
        checkInput();

        if (m_rigidbody.velocity.magnitude > 30)
        {
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x - 0.1f, m_rigidbody.velocity.y - 0.1f);

        }
        if (this.transform.position.y < minHeight)
        {
            Destroy(this);
        }



    }
    ///////////////////////////////////////////////////////////////Inputs///////////////////////////////////////////////////////////////
    public void checkInput()
    {
     if(permaDeath == true)
        {
            m_Anim.Play("Die");
            return;
        }   
        
            
       

        //if (Input.Ge)
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
        else if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown < 0)
        {
            if (swordsmanFaceRight == true)
            {
                m_rigidbody.AddForce(Vector2.right * dashSpeed);
            }
            else if (swordsmanFaceRight == false)
            {
                m_rigidbody.AddForce(Vector2.left * dashSpeed);
            }

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


        m_MoveX = Input.GetAxis("Horizontal")*-1;



        GroundCheckUpdate();


        if (!m_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {


                m_Anim.Play("Attack");
                if (swordsmanFaceRight == true)
                {
                    Vector3 spawnposition = this.transform.position + new Vector3(.6f, 0.1f);
                    GameObject shoot = Instantiate(swordBullet, spawnposition, Quaternion.Euler(0f, 0f, -90f));
                    shoot.GetComponent<Rigidbody2D>().AddForce(Vector2.right * swordSpeed);
                }
                else if (swordsmanFaceRight == false)
                {
                    Vector3 spawnposition = this.transform.position + new Vector3(-.6f, 0.1f);
                    GameObject shoot = Instantiate(swordBullet, spawnposition, swordBullet.transform.rotation);
                    shoot.GetComponent<Rigidbody2D>().AddForce(Vector2.left * swordSpeed);
                }
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
        if (Input.GetKey(KeyCode.A))
        {
            swordsmanFaceRight = true;

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
                Filp(false);


        }
        else if (Input.GetKey(KeyCode.D))
        {
            swordsmanFaceRight = false;

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

            if (!Input.GetKey(KeyCode.A))
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
    ////////////////////////////////////////////////////////////Collisions and Colliders//////////////////////////////////////////////////////////////////
    //Come Back to timeOut Variable
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coin") && timeOut <= 0)
        {
            col.gameObject.SetActive(false);
            Destroy(col.gameObject);
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
            col.gameObject.SetActive(false);
            Destroy(col.gameObject);

        }
        else if (col.CompareTag("heartPowerUp") && timeOut <= 0)
        {
            col.gameObject.SetActive(false);
            Destroy(col.gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
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
        else if (col.gameObject.tag == "Breakable")
        {
            currentJumpCount = 0;
            Debug.Log(currentJumpCount + "");
            Debug.Log("Player touching Breakable");
        }

    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Deadly" && timeOut <= 0 && rebornTime <= 0)
        {
            permaDeath = true;
            m_Anim.Play("Die");
            Destroy(this);
        }
        if (col.gameObject.tag == "Sticky")
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
