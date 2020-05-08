using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpaceControlSpawner : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn;
    public float spawnDelay = 2;
    public float spawnDistance = 1.1f;

    private float elapsedTime;

    Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime > spawnDelay)
        {
            Vector3 direction = Random.insideUnitSphere.normalized;
            Vector3 spawnPos = direction * spawnDistance;
            GameObject spaceObject;
            spaceObject = Instantiate(ObjectsToSpawn[Random.Range(0, ObjectsToSpawn.Length)], spawnPos, Quaternion.Euler(0, 0, 0), parent);

            elapsedTime = 0;
        }
    }
}
