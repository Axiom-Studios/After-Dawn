using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawnManager : MonoBehaviour
{
    private Vector3 sphereSpawnPos;
    private float sphereSpawn;
    public GameObject TimeSphere;
    // Start is called before the first frame update
    void Start()
    {
        sphereSpawn = Time.time + 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= sphereSpawn){
            sphereSpawnPos.x = Random.Range(-9, 9);
            sphereSpawnPos.y = 2;
            sphereSpawnPos.z = Random.Range(-9, 9);
            Instantiate(TimeSphere, sphereSpawnPos, transform.rotation);
            sphereSpawn = Time.time + 5;
        }
    }
}
