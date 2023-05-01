using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditGroundCheck : MonoBehaviour
{
    [SerializeField]
    BanditAI bandit;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6 || collision.gameObject.layer == 8)
        {
            bandit.isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 8)
        {
            bandit.isGrounded = false;
        }
    }
}
