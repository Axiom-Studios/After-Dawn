using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StellarOrb : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player.beacons += 1;
            Destroy(gameObject);
        }
    }
}
