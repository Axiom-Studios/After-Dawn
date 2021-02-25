using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    List<string> sentencesQueue = new List<string>();
    // Update is called once per frame
    void Update()
    {
        if (sentencesQueue.Count == 0)
        {
            dialogueBox.SetActive(false);
        }
        else
        {
            dialogueText.text = sentencesQueue[0];
            dialogueBox.SetActive(true);
        }
    }
}
