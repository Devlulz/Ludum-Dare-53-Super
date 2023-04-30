using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
