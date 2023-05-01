using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PeaShooter : Gun
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool OutOfAmmo()
    {
        shotDelay = 5;
        shots = shotCapacity;
        return true;
    }

}
