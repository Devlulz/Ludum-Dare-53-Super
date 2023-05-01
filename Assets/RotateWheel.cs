using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 1f;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0,0, rotationSpeed, Space.Self);
    }
}
