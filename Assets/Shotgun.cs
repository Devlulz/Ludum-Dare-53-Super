using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField]
    int pellets = 5;

    public override bool OutOfAmmo()
    {
        Destroy(gameObject);
        return true;
    }

    public override bool Shoot()
    {
        for (int i = 0; i < pellets; i++)
        {
            base.Shoot();
        }
        shotDelay = 1 / (RPM / 60);
        return true;
    }
}
