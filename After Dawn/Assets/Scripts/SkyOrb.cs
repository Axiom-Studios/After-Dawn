using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyOrb : MonoBehaviour
{
    public Camera playerCamera;
    public Camera skyCamera;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!DialogueManager.skyExplained)
            {
                DialogueManager.sentencesQueue.Add("Sky orbs allow you to see from the sky for 5 seconds");
                DialogueManager.skyExplained = true;
            }

            StartCoroutine(switchForFive());
        }
    }

    IEnumerator switchForFive()
    {
        playerCamera.enabled = false;
        skyCamera.enabled = true;

        yield return new WaitForSeconds(5);

        skyCamera.enabled = false;
        playerCamera.enabled = true;
        Destroy(gameObject);
    }
}
