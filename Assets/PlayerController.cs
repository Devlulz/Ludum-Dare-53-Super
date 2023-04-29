using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    int xAccel = 1;
    [SerializeField]
    int xMax = 10;
    [SerializeField]
    int yAccel = 1;
    [SerializeField]
    float airControlMod = 1;
    [SerializeField]
    int gravRise = 1;
    [SerializeField]
    int gravFall = 3;
    [SerializeField]
    float distToGround;
    [SerializeField]
    float distBetweenSides;

    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    Collider2D col;
    LayerMask lm;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        distToGround = col.bounds.extents.y;
        distBetweenSides = col.bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            Debug.Log("Jump");
            rb.AddForce(Vector2.up * yAccel);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.1f, LayerMask.GetMask("Ground"));
    }
   

    private void FixedUpdate()
    {
        if (IsGrounded())
        {
            if (Input.GetKey(KeyCode.D))
                rb.AddForce(Vector2.right * xAccel);
            else if (Input.GetKey(KeyCode.A))
                rb.AddForce(Vector2.left * xAccel);
            else
                rb.velocity = new Vector2(0, rb.velocity.y);
        }

        else
        {
            if (Input.GetKey(KeyCode.D))
                rb.AddForce(Vector2.right * xAccel * airControlMod);
            else if (Input.GetKey(KeyCode.A))
                rb.AddForce(Vector2.left * xAccel * airControlMod);
        }
            

            

        if (Mathf.Abs(rb.velocity.x) > xMax)
        {
            Debug.Log("testX");
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -xMax, xMax), rb.velocity.y);
        }


        if (rb.velocity.y < -.1)
            rb.gravityScale = gravFall;
        else
            rb.gravityScale = gravRise;
    }
}
