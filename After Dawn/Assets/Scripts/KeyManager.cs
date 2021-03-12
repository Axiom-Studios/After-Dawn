using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public bool collected = false;
    void Update()
    {
        if (DayNightCycle.night && collected)
        {
            if (Player.passed)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.Translate(0, 100, 0);
                collected = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!DialogueManager.keyExplained)
            {
                DialogueManager.sentencesQueue.Clear();
                DialogueManager.sentencesQueue.Add("Keys must be collected every day");
                DialogueManager.sentencesQueue.Add("They are often placed in random locations throughout the map");
                DialogueManager.sentencesQueue.Add("They are required to enter camp and complete the day");
                DialogueManager.keyExplained = true;
            }
            Player.hasKey = true;
            transform.Translate(0, -100, 0);
            collected = true;
        }
    }
}
