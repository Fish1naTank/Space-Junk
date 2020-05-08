using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBox : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SpaceDebris(Clone)")
        {
            Destroy(other.gameObject);
        }
    }
}
