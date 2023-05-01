using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideCarriageFade : MonoBehaviour
{
    [SerializeField]
    Animator sprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprite.Play("Fade out");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprite.Play("Fade in");
        }
    }
}
