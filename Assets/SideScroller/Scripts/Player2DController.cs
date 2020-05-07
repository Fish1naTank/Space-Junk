using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DController : MonoBehaviour
{
    public float moveRange = 8;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float newPosY = Camera.main.ScreenToViewportPoint(Input.mousePosition).y;
        this.transform.position = new Vector3(this.transform.position.x, newPosY * moveRange, this.transform.position.z);
    }
}
