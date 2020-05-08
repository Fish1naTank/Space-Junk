using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform OrbitCenter;
    public Vector3 OrbitDirection = new Vector3(0,0,0);
    public float orbitSpeed = 4.0f;

    private Vector3 offset;

    // Start is called before the first frame update
    void Awake()
    {
        if(OrbitCenter == null)
        {
            OrbitCenter = this.transform.parent;
        }

        if(OrbitDirection == Vector3.zero)
        {
            OrbitDirection = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
            orbitSpeed = Random.Range(1, 6);
        }

        offset = this.transform.position - OrbitCenter.transform.position;
        this.transform.LookAt(OrbitCenter);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = OrbitCenter.position;
        this.transform.Rotate(OrbitDirection.normalized * orbitSpeed * Time.deltaTime);
        this.transform.position = offset.magnitude * -this.transform.forward;
    }
}
