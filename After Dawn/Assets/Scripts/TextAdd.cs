using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAdd : MonoBehaviour
{
    public string text = "ERROR: default text";
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DialogueManager.sentencesQueue.Clear();
            DialogueManager.sentencesQueue.Add(text);
            Destroy(gameObject);
        }
    }
}
