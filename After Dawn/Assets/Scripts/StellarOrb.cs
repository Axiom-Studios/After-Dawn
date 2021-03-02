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
            if (!DialogueManager.stellarExplained)
            {
                DialogueManager.sentencesQueue.Add("Purple orbs seem to allow you to place a beacon");
                DialogueManager.sentencesQueue.Add("Right click to place on in your current location");
                DialogueManager.stellarExplained = true;
            }
            Destroy(gameObject);
        }
    }
}
