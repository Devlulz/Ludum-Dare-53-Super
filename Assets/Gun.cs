using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Gun : MonoBehaviour
{
    public int capacity = 1;
    public int range = 10;
    public float deviation = 0;
    public float shotDelay;
    public float RPM;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public void FixedUpdate()
    {
        if (shotDelay > 0)
        {
            shotDelay -= .02f;
        }
    }

    virtual public void Activate(Vector2 dir)
    {
        if (shotDelay <= 0)
        {
            Shoot(dir);
        }
    }

    virtual public void Deactivate()
    {

    }

    virtual public bool Shoot(Vector2 dir)
    {
        
            Quaternion spread = Quaternion.AngleAxis(Random.Range(-deviation, deviation), Vector3.forward);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, spread * dir, range, LayerMask.GetMask("Hostile"));
            if (hit.collider != null)
                hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            UnityEngine.Debug.DrawRay(transform.position, (spread * dir).normalized * range, Color.blue, 10f);
            shotDelay = 1 / (RPM / 60);
            return true;
    }

    abstract public bool OutOfAmmo();
}
