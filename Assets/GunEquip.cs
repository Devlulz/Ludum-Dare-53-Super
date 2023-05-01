using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquip : MonoBehaviour
{
    [SerializeField]
    Gun gun;
    [SerializeField]
    PlayerController pc;

    private void Start()
    {
        pc.equipedGun = gun;
    }
}
