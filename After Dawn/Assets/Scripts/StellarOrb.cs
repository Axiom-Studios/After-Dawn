using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StellarOrb : MonoBehaviour
{
	AudioSource source;
	void Start(){
		source = gameObject.GetComponent<AudioSource>();
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            DialogueManager.orbs += 1;
            Player.beacons += 1;
			source.Play();
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
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		yield return new WaitForSeconds(.5f);
		Destroy(gameObject);
	}
}
