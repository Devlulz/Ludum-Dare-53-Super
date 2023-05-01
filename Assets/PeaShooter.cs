using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PeaShooter : Gun
{
    [SerializeField]
    float reloadTime = 5;

    [SerializeField]
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Shoot()
    {
        base.Shoot();
        anim.Play("BANG");

        shotDelay = 1 / (RPM / 60);
        return true;
    }

    public override bool OutOfAmmo()
    {
        shotDelay = reloadTime;
        shots = shotCapacity;
        return true;
    }

}
