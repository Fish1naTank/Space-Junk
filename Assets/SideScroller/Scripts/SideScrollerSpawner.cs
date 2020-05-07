using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerSpawner : MonoBehaviour
{
    public Rigidbody[] ObjectsToSpawn;
    public Vector3 spawnDirection;
    public float force;

    public float secondsBetweenSpawn = 2;
    public float elapsedTime = 0.0f;

    private List<Rigidbody> _spawedObjects;

    void Start()
    {
        _spawedObjects = new List<Rigidbody>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;

            Vector3 spawnPosition = this.transform.position + new Vector3(0, Random.Range(-4.0f, 4.0f), 0);
            Rigidbody newObject;
            newObject = Instantiate(ObjectsToSpawn[Random.Range(0, ObjectsToSpawn.Length)], spawnPosition, this.transform.rotation);
            newObject.AddForce(spawnDirection * force);

            _spawedObjects.Add(newObject);
        }

        foreach(Rigidbody spawedObject in _spawedObjects.ToArray())
        {
            Vector3 objectPos = spawedObject.transform.position;
            if ((objectPos.y > 10 || objectPos.y < -10) || (objectPos.x > 15 || objectPos.y < -15))
            {
                _spawedObjects.Remove(spawedObject);
                Destroy(spawedObject.gameObject);
            }
        }
    }
}
