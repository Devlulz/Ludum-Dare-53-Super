using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    Material flash;

    [SerializeField]
    Material OGMat;
    [SerializeField]
    float duration;

    [SerializeField]
    SpriteRenderer sprite;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        GetComponent<AudioSource>().Play();
        StartCoroutine(FlashEffect());
        if (health < 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(.15f);
        Destroy(gameObject);
    }

    IEnumerator FlashEffect()
    {
        sprite.material = flash;
        yield return new WaitForSeconds(duration);
        sprite.material = OGMat;
    }
}
