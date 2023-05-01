using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAI : MonoBehaviour
{
    [SerializeField]
    float distToGround = .52f;

    float xDistToPlayer;

    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float maxSpeed = 5f;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    Animator anim;

    Rigidbody2D rb;

    public bool isGrounded;
    public bool walkingRight = true;
    bool stuckJumping;
    public bool wallCheck;
    public bool playerDetected;

    //difference between player Y and Bandit Y
    [SerializeField]
    float yDifference;

    [SerializeField]
    float xVel;
    [SerializeField]
    float yVel;

    GameObject player;

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform firePoint;

    float fireInterval = 1f;
    float intervalTimer;

    bool stopWalking;
    [SerializeField]
    float distanceUntilJump;

    int xDir;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        intervalTimer = fireInterval;
    }
    void Update()
    {
        if(player.transform.position.x < transform.position.x)
        {
            walkingRight = false;
            xDir = -1;
            anim.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            walkingRight = true;
            xDir = 1;
            anim.transform.localScale = new Vector3(1, 1, 1);
        }
        yDifference = transform.position.y - player.transform.position.y;
        xVel = rb.velocity.x;
        yVel = rb.velocity.y;
        if(wallCheck && !stuckJumping)
        {
            stopWalking = true;
        }
        else if(wallCheck && stuckJumping)
        {
            stopWalking = false;
        }
        /*if (Input.GetKeyDown(KeyCode.F))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Shoot();
        }*/
        if (xVel == 0 && yVel == 0)
        {
            anim.Play("Idle");
        }
    }

    private void FixedUpdate()
    {
        if (playerDetected)
        {
            Attack();
        }
        else 
        {
            stopWalking = false;
        }
        if (isGrounded && !playerDetected && !stopWalking)
        {
            //Debug.Log("AI IS ON THE GROUND");
            Walk();
        }
        if(!isGrounded)
        {
            anim.Play("Jump");
        }
        LimitVelocity();
        if (stuckJumping && !wallCheck)
        {
            //rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        }
    }

    void Walk()
    {
        rb.AddForce(new Vector2(xDir, 0) * speed, ForceMode2D.Impulse);
        if (Mathf.Abs(xVel) > 0 && isGrounded)
        {
            anim.Play("Run");
            stuckJumping = false;
        }
            
        if (xVel == 0 && wallCheck && stopWalking && isGrounded)
        {
            anim.Play("Idle");
            StartCoroutine(StuckJump());
        }
    }

    void Attack()
    {
        stopWalking = true;
        if(transform.position.y > player.transform.position.y)
        {
            Walk();
        }
        if (Mathf.Abs(yDifference) < 10)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Debug.Log("FUCKIN SHOOTING");
        intervalTimer -= .02f;
        if(intervalTimer < 0.1f && yDifference < distanceUntilJump)
        {
            
            //Debug.Log("REACH");
            Jump();
        }
        if(intervalTimer < 0)
        {
            GameObject spawnedBullet = Instantiate(bullet, firePoint.position, transform.rotation);
            spawnedBullet.GetComponent<EnemyBullet>().xDir = xDir;
            intervalTimer = fireInterval;
        }
        
    }
    IEnumerator StuckJump()
    {
        yield return new WaitForSeconds(1f);
        if (xVel == 0)
        {
            Jump();
            stuckJumping = true;
            //Debug.Log("TRYING");
            StartCoroutine(WHEREISYOURGODNOW());
        }
    }

    IEnumerator WHEREISYOURGODNOW()
    {
        yield return new WaitForSeconds(1.2f);
        stuckJumping = false;
    }

    void Jump()
    {
        if(IsGrounded())
            rb.AddForce(Vector2.up * jumpForce);
    }

    void Stop()
    {
        rb.velocity = Vector2.zero;
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.1f, LayerMask.GetMask("Ground", "OneWayPlatform"));
    }

    void LimitVelocity()
    {
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed * xDir , rb.velocity.y);
        }
    }
}
