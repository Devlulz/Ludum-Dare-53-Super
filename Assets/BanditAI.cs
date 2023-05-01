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

    [SerializeField]
    float xVel;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        xVel = rb.velocity.x;
        if (Input.GetKeyDown(KeyCode.F))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            //Debug.Log("AI IS ON THE GROUND");
            Walk();
        }
        else
        {
            anim.Play("Jump");
        }
        LimitVelocity();
        if (stuckJumping && !wallCheck)
        {
            Debug.Log("bruh");
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

    IEnumerator StuckJump()
    {
        yield return new WaitForSeconds(1f);
        if (xVel == 0)
        {
            Jump();
            stuckJumping = true;
            Debug.Log("TRYING");
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
