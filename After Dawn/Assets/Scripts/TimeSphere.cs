using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSphere : MonoBehaviour
{
    public float timeAdded;
    public string explanationMessage = "These white orbs seem to push back time slightly.";
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            //when coliding with player, add time to the day and destroy the sphere.
            DayNightCycle.sunset += timeAdded;
            if (!DialogueManager.timeExplained)
            {
                DialogueManager.sentencesQueue.Add(explanationMessage);
                DialogueManager.timeExplained = true;
            }
            Destroy(gameObject);
        }    
    }
}
