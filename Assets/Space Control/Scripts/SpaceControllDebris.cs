using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OrbitObjectController))]
public class SpaceControllDebris : MonoBehaviour
{
    public Vector3 startingScale = new Vector3(1, 1, 1);

    OrbitObjectController orbitObject;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = startingScale / this.transform.lossyScale.x / 2;
        orbitObject = GetComponent<OrbitObjectController>();
        orbitObject.direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Destroy(this.gameObject);
    }
}
