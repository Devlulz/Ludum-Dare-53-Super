using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    int dmg = 1;

    private void Start()
    {
        StartCoroutine(DeathTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Unit>().TakeDMG(dmg);
            StopAllCoroutines();
            Destroy(gameObject);
        }
        else
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = (Vector2.right * 5);
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
}
