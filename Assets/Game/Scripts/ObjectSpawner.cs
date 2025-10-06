using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate;
    private float nextSpawnTime = 0f;

    public bool needDestroy;
    public float timeToDestroy;

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            GameObject spawnedPrefab = Instantiate(prefab, transform.position, transform.rotation);
            if (needDestroy)
            {
                Destroy(spawnedPrefab,timeToDestroy);
            }
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
