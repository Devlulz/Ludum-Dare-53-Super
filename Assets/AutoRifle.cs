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
        if (firing)
        {
            Shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        }
    }

    public override void Activate(Vector2 dir)
    {
        firing = true;
    }

    public override void Deactivate()
    {
        firing = false;
    }

    public override bool OutOfAmmo()
    {
        UnityEngine.Debug.Log("Drop Gun");
        return true;
    }
}
