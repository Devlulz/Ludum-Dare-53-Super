using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditSpawner : MonoBehaviour
{
    public Transform jumpPoint;
    Vector3 jumpOffset;
    bool reachedPoint;

    [SerializeField]
    GameObject banditPrefab;

    // Start is called before the first frame update
    void Start()
    {
        jumpOffset = new Vector3(Random.Range(0f,3f), 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!reachedPoint)
            transform.position += new Vector3((-15f * .7f) * Time.deltaTime, 0,0);
        if(transform.position.x < (jumpPoint.position + jumpOffset).x)
        {
            reachedPoint = true;
            JumpUpAndSpawn();
        }
    }

    void JumpUpAndSpawn()
    {
        transform.position += new Vector3(0,(8) * Time.deltaTime, 0);
        if(transform.position.y > -5)
        {
            Instantiate(banditPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
