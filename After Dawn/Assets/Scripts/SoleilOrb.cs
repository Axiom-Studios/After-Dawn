using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoleilOrb : MonoBehaviour
{
    public string explanationMessage = "These orange orbs seem to lengthen the day slightly.";
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            DayNightCycle.dayLength += 20f;
            DayNightCycle.sunset += 20f;
            DayNightCycle.initialSunset += 20f;
            if (!DialogueManager.soleilExplained)
            {
                DialogueManager.sentencesQueue.Add(explanationMessage);
                DialogueManager.soleilExplained = true;
            }
            Destroy(gameObject);
        }
    }
}
