using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StellarOrb : MonoBehaviour
{
    public string explanationMessage = "These purple orbs seem to allow me to place a beacon visible from most of the maze.";
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player.beacons += 1;
            if (!DialogueManager.stellarExplained)
            {
                DialogueManager.sentencesQueue.Add(explanationMessage);
                DialogueManager.stellarExplained = true;
            }
            Destroy(gameObject);
        }
    }
}
