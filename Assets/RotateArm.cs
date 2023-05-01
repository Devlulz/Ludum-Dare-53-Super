using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArm : MonoBehaviour
{
    [SerializeField]
    PlayerController pc;


    float rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.facingRight && pc.equipedGun != null)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            pc.equipedGun.transform.localPosition = new Vector3(-0.318f, 0.0625f, 0);
            pc.equipedGun.transform.parent.localScale = new Vector3(1, -1, 1);
        }
            
        else if(!pc.facingRight && pc.equipedGun != null)
        {
            transform.localScale = new Vector3(1, 1, 1);
            pc.equipedGun.transform.localPosition = new Vector3(-0.318f, 0.0625f,0f);
            pc.equipedGun.transform.parent.localScale = new Vector3(1, 1, 1);
        }
            

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);
    }

    float Rotation()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        return Vector2.Angle(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);
    }
}
