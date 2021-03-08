using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image Canvas;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    public float messageDuration = 3f;
    public static List<string> sentencesQueue = new List<string>();

    // message explained bools
    public static bool timeExplained = false;
    public static bool stellarExplained = false;
    public static bool soleilExplained = false;
    public static bool lumineExplained = false;
    public static bool skyExplained = false;
    float t1 = 0;

    // Update is called once per frame
    void Update()
    {
        if (sentencesQueue.Count == 0 || PauseMenu.paused)
        {
            dialogueBox.SetActive(false);
        }
        else
        {
            dialogueBox.SetActive(true);
            Canvas.color = new Color(0, 0, 0, 0.3f);
            if (dialogueText.text != sentencesQueue[0])
            {
                dialogueText.text = sentencesQueue[0];
                t1 = Time.time;
            }
            if (Time.time - t1 > messageDuration)
            {
                sentencesQueue.RemoveAt(0);
                if (sentencesQueue.Count == 0)
                {
                    Canvas.color = new Color(0, 0, 0, 0);
                }
            }
        }
    }
}
