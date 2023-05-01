using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PeaShooter : Gun
{
    [SerializeField]
    float reloadTime = 5;
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
        shotDelay = reloadTime;
        shots = shotCapacity;
        return true;
    }

}
