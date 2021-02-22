using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoleilOrb : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            DayNightCycle.dayLength += 20f;
            DayNightCycle.sunset += 20f;
            Destroy(gameObject);
        }
    }
}
