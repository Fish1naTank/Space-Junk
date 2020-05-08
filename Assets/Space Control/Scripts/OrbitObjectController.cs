using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitObjectController : MonoBehaviour
{
    public Vector2 direction;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction.Normalize();
        transform.RotateAround(transform.parent.position, -transform.parent.up, direction.x * speed * Time.deltaTime);
        transform.RotateAround(transform.parent.position, transform.parent.right, direction.y * speed * Time.deltaTime);
    }
}
