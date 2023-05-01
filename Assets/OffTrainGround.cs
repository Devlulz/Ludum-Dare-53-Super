using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffTrainGround : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = Vector3.zero;
            //remove health and reset player position
        }
    }
}
