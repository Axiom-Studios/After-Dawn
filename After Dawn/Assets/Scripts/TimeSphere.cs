using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSphere : MonoBehaviour
{
    public float timeAdded;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            //when coliding with player, add time to the day and destroy the sphere.
            DayNightCycle.sunset += timeAdded;
            Destroy(gameObject);
        }    
    }
}
