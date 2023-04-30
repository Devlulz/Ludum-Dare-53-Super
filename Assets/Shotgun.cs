using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField]
    int damage = 20;
    [SerializeField]
    int range = 10;
    [SerializeField]
    int pellets = 5;
    [SerializeField]
    float deviation = 10;
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
        
        for (int i = 0; i < pellets; i++)
        {
            Quaternion spread = Quaternion.AngleAxis(Random.Range(-deviation, deviation), Vector3.forward);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, spread * dir, range, LayerMask.GetMask("Hostile"));
            if (hit.collider != null)
                hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            UnityEngine.Debug.DrawRay(transform.position, (spread * dir).normalized * range, Color.blue, 10f);
        }
       
        return true;
    }
}
