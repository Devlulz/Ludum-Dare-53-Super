using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCrraigeAnimEvents : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    public void ToIdle()
    {
        anim.Play("Idle");
    }
    public void ToInvis()
    {
        anim.Play("Invisible");
    }
}
