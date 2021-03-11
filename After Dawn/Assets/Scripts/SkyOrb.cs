using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyOrb : MonoBehaviour
{
    public Camera playerCamera;
    public Camera skyCamera;
    public static bool skyActive = false;
    float lookTime = 7f;
	AudioSource source;
    void Start()
    {
        playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        skyCamera = GameObject.Find("Sky Camera").GetComponent<Camera>();
		source = gameObject.GetComponent<AudioSource>();
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
        }
    }

    IEnumerator switchForX()
    {
        playerCamera.enabled = false;
        skyCamera.enabled = true;

        yield return new WaitForSeconds(lookTime);

        skyCamera.enabled = false;
        playerCamera.enabled = true;
        skyActive = false;
        Destroy(gameObject);
    }
}
