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
            if (!DialogueManager.timeExplained)
            {
                DialogueManager.sentencesQueue.Clear();
                DialogueManager.sentencesQueue.Add("White orbs push back the island\'s time a bit");
                DialogueManager.timeExplained = true;
            }
            Destroy(gameObject);
        }    
    }
}
