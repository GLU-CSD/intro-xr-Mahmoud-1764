using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;       
    public float spawnInterval = 5f;      
    private float lastSpawnTime;         

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastSpawnTime + spawnInterval)
        {
            SpawnObject ();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnObject()
    {
        if (objectToSpawn != null)
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("Object to spawn is not set.");
        }
    }
}
