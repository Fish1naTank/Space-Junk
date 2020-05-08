using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    public float rotationSpeed = 100;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotX, Space.World);
        transform.Rotate(Vector3.right, rotY, Space.World);
    }
}
