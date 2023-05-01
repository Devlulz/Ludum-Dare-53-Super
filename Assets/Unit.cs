using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    int HP;

    [SerializeField]
    int maxHP = 10;

    private void Start()
    {
        HP = maxHP;
    }

    public void TakeDMG(int DMG)
    {
        HP -= DMG;
    }

    void CheckDeath()
    {
        if(HP <= 0)
        {
            FuckingDie();
        }
    }

    void FuckingDie()
    {
        Debug.Log("oh... Dead");
    }
}
