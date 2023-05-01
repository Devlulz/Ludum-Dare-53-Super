using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPopUp : MonoBehaviour
{
    [SerializeField]
    GameObject arrow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        arrow.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        arrow.SetActive(false);
    }
}
