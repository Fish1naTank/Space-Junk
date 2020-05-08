using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseObjectController : MonoBehaviour
{
    public Collider WorldObject;
    public float rotationSpeed = 100;

    Collider selectedObject;

    Vector3 mouseClickPos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            selectedObject = WorldObject;

            mouseClickPos = Input.mousePosition;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                selectedObject = hit.collider;
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (selectedObject != WorldObject) return;

            float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

            selectedObject.transform.Rotate(Vector3.up, -rotX, Space.World);
            selectedObject.transform.Rotate(Vector3.right, rotY, Space.World);
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (selectedObject != null && selectedObject != WorldObject)
            {
                //fix
                //Vector2 newDirection = Input.mousePosition - mouseClickPos;

                Vector2 newDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
                selectedObject.GetComponent<OrbitObjectController>().direction = newDirection;

                selectedObject.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
