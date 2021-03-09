using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoleilOrb : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            DialogueManager.orbs += 1;
            DayNightCycle.dayLength += 20f;
            DayNightCycle.sunset += 20f;
            DayNightCycle.initialSunset += 20f;
            if (!DialogueManager.soleilExplained)
            {
                DialogueManager.sentencesQueue.Add("Orange orbs make the day a bit longer");
                DialogueManager.soleilExplained = true;
            }
            Destroy(gameObject);
        }
    }
}
