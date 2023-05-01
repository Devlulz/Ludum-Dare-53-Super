using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Gun : MonoBehaviour
{
    public int shotCapacity = 5;
    public int shots = 6;
    public int range = 10;
    public float deviation = 0;
    public float shotDelay = 0;
    public float RPM = 60;
    public int damage = 10;

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

    virtual public void Activate()
    {
        if (shotDelay <= 0)
        {
            Shoot();
            shots -= 1;
        }
    }

    virtual public void Deactivate()
    {

    }

    virtual public bool Shoot()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Quaternion spread = Quaternion.AngleAxis(Random.Range(-deviation, deviation), Vector3.forward);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, spread * dir, range, LayerMask.GetMask("Hostile"));
        if (hit.collider != null)
            hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        UnityEngine.Debug.DrawRay(transform.position, (spread * dir).normalized * range, Color.blue, 10f);
        shotDelay = 1 / (RPM / 60);
        if (shots <= 0)
        {
            OutOfAmmo();
            return false;
        }
        else
            return true;
    }

    abstract public bool OutOfAmmo();

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().EquipGun(this);
        }
    }
}
