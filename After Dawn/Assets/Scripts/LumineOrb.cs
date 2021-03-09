﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumineOrb : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            DialogueManager.orbs += 1;
            Player.walkSpeed += 0.5f;
            //Player.runSpeed += 0.5f;
            if (!DialogueManager.lumineExplained)
            {
                DialogueManager.sentencesQueue.Add("Blue orbs make you faster");
                DialogueManager.lumineExplained = true;
            }
            Destroy(gameObject);
        }
    }
}
