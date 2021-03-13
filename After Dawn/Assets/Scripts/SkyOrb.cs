using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkyOrb : MonoBehaviour
{
    public Camera playerCamera;
    public Camera skyCamera;
    public Image pointer;
    public static bool skyActive = false;
    float lookTime = 7f;
    public bool collected = false;
	AudioSource source;
    void Start()
    {
        playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        skyCamera = GameObject.Find("Sky Camera").GetComponent<Camera>();
        pointer = GameObject.Find("Pointer").GetComponent<Image>();
        pointer.enabled = false;
		source = gameObject.GetComponent<AudioSource>();
    }

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
			source.Play();
            if (!DialogueManager.skyExplained)
            {
                DialogueManager.sentencesQueue.Clear();
                DialogueManager.sentencesQueue.Add("Sky orbs allow you to see from the sky for 7 seconds");
                DialogueManager.skyExplained = true;
            }

            skyActive = true;
            StartCoroutine(switchForX());
            transform.Translate(0, -100, 0);
            collected = true;
        }
    }

    IEnumerator switchForX()
    {
        playerCamera.enabled = false;
        skyCamera.enabled = true;
        pointer.enabled = true;

        yield return new WaitForSeconds(lookTime);

        skyCamera.enabled = false;
        playerCamera.enabled = true;
        skyActive = false;
        pointer.enabled = false;
    }
}
