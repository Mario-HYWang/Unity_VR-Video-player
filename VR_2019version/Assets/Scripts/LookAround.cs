using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public float rotateSpeed = 3f;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(transform.position, -Vector3.up, rotateSpeed * Input.GetAxis("Mouse X"));
            transform.RotateAround(transform.position, transform.right, rotateSpeed * Input.GetAxis("Mouse Y"));
        }
    }
}
