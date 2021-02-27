using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumineOrb : MonoBehaviour
{
    public string explanationMessage = "These blue orbs seem to speed time around me, making me slightly faster.";
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player.walkSpeed += 0.5f;
            //Player.runSpeed += 0.5f;
            if (!DialogueManager.lumineExplained)
            {
                DialogueManager.sentencesQueue.Add(explanationMessage);
                DialogueManager.lumineExplained = true;
            }
            Destroy(gameObject);
        }
    }
}
