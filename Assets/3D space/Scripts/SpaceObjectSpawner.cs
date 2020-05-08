using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObjectSpawner : MonoBehaviour
{
    public GameObject[] SpaceObjects;
    public int numberOfObjects = 100;
    public Vector2 distFromCenter = new Vector2(0, 1);

    public Vector3 OrbitRotation = new Vector3(1, 3, 5);

    private float parentSurface = 0;

    // Start is called before the first frame update
    void Start()
    {
        Transform parentTransform = this.GetComponentInParent<Transform>();

        Vector3 center = transform.position;
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 pos = RandomCircle(center, Random.Range(distFromCenter.x, distFromCenter.y));
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            GameObject spaceObject;
            spaceObject = Instantiate(SpaceObjects[Random.Range(0, SpaceObjects.Length)], pos, rot, this.transform);
            spaceObject.transform.localScale = new Vector3(1,1,1) * Random.Range(3, 10);
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z + Random.Range(0, distFromCenter.y - distFromCenter.x);
        return pos;
    }

    void Update()
    {
        this.transform.Rotate(OrbitRotation * Time.deltaTime);
    }
}
