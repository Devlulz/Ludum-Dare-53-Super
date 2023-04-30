using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PeaShooter : Gun
{
    [SerializeField]
    int damage = 20;
    [SerializeField]
    int range = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Shoot(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,dir,range,LayerMask.GetMask("Hostile"));
        if(hit.collider != null)
            hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        UnityEngine.Debug.DrawRay(transform.position, dir, Color.blue, 10f);
        return true;
    }
}
