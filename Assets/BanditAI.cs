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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        yDifference = transform.position.y - player.transform.position.y;
        xVel = rb.velocity.x;
        yVel = rb.velocity.y;
        if (Input.GetKeyDown(KeyCode.F))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Shoot();
        }
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
        else if (isGrounded && !playerDetected)
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
            rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        }
    }

    void Walk()
    {
        rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        if(xVel > 0)
        {
            anim.Play("Run");
            stuckJumping = false;
        }
            
        if (xVel == 0)
        {
            anim.Play("Idle");
            StartCoroutine(StuckJump());
        }
    }

    void Attack()
    {
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
        Debug.Log("FUCKIN SHOOTING");
        intervalTimer -= .02f;
        if(intervalTimer < 0)
        {
            Instantiate(bullet, firePoint.position, transform.rotation);
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
        }
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
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed , rb.velocity.y);
        }
    }
}
