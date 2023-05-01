using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AutoRifle : Gun
{
    bool firing;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void  FixedUpdate()
    {
        base.FixedUpdate();
        if (firing && shotDelay <= 0)
        {
            Shoot();
            shots -= 1;
        }
    }

    public override void Activate()
    {
        firing = true;
    }

    public override void Deactivate()
    {
        firing = false;
    }

    public override bool OutOfAmmo()
    {
        Destroy(gameObject);
        return true;
    }
}
