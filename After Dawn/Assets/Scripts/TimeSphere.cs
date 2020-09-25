using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSphere : MonoBehaviour
{
    private float timeAdded;
    // Start is called before the first frame update
    void Start()
    {
        timeAdded = Random.Range(1, 5);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            //when coliding with player, add time to the day and destroy the sphere.
            DayNightCycle.sunset += timeAdded;
            Destroy(gameObject);
        }    
    }
}
