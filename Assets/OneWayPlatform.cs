using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    bool playerOnTop;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerOnTop = true;
    }
    /*private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown("s"))
        {
            Debug.Log("hahaha");
            StartCoroutine(DisableCollision(collision.gameObject.GetComponent<Collider2D>()));
        }
    }*/
    private void Update()
    {
        if(playerOnTop && Input.GetKeyDown("s"))
        {
            Debug.Log("hahaha");
            StartCoroutine(DisableCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()));
        }
    }

    private IEnumerator DisableCollision(Collider2D collision)
    {
        Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        yield return new WaitForSeconds(.25f);
        Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>(), false);
        playerOnTop = false;
    }
}
