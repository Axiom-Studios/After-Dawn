using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StellarOrb : MonoBehaviour
{

    public bool collected = false;
	AudioSource source;
	void Start(){
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
            DialogueManager.orbs += 1;
            Player.beacons += 1;
			source.Play();
            transform.Translate(0, -100, 0);
            collected = true;
			StartCoroutine(PlaySound(source));
            
            if (!DialogueManager.stellarExplained)
            {
                DialogueManager.sentencesQueue.Clear();
                DialogueManager.sentencesQueue.Add("Purple orbs seem to allow you to place a beacon");
                DialogueManager.sentencesQueue.Add("Right click to place on in your current location");
                DialogueManager.stellarExplained = true;
            }
            
        }
    }

	IEnumerator PlaySound(AudioSource source){
		source.Play();
		yield return new WaitForSeconds(.5f);
		
	}
}
