using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Camera cam;
    [SerializeField]
    float maxX;
    [SerializeField]
    float minX;
    [SerializeField]
    float maxY;
    [SerializeField]
    float minY;
    [SerializeField]
    float timeOffset = 1;
    [SerializeField]
    Vector3 velocity = Vector3.zero;

    float camHalfHeight;
    float camHalfWidth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 endpos = player.position + new Vector3(0,0,-10);
        camHalfHeight = (2f * cam.orthographicSize) / 2;
        camHalfWidth = camHalfHeight * cam.aspect;


        transform.position = Vector3.SmoothDamp(transform.position, endpos, ref velocity,timeOffset);
        /*
        transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, minX + camHalfWidth, maxX - camHalfWidth),
                Mathf.Clamp(transform.position.y, minY + camHalfHeight, maxY - camHalfHeight),
                transform.position.z
            );
        */
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(minX, maxY), new Vector2(maxX, maxY));
        Gizmos.DrawLine(new Vector2(maxX, maxY), new Vector2(maxX, minY));
        Gizmos.DrawLine(new Vector2(maxX, minY), new Vector2(minX, minY));
        Gizmos.DrawLine(new Vector2(minX, minY), new Vector2(minX, maxY));

    }


}
