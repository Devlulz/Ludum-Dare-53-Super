using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField]
    int pellets = 5;
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
        UnityEngine.Debug.Log("Drop Gun");
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
