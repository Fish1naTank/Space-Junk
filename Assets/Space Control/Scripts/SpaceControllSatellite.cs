using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OrbitObjectController))]
public class SpaceControllSatellite : MonoBehaviour
{
    public Vector3 startingScale = new Vector3(2, 2, 2);

    public GameObject debris;

    OrbitObjectController orbitObject;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = startingScale / this.transform.lossyScale.x;
        orbitObject = GetComponent<OrbitObjectController>();
        orbitObject.direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject deathDebris;
        deathDebris = Instantiate(debris, this.transform.position, Quaternion.Euler(0,0,0), this.transform.parent);
        Destroy(this.gameObject);
    }
}
