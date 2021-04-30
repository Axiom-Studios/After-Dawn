using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    AudioSource source;
    public Vector3 coords;
    public GameObject player;
	void Start(){
		source = gameObject.GetComponent<AudioSource>();
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.transform.position = coords;
			source.Play();
			StartCoroutine(PlaySound(source));
            
            if (!DialogueManager.teleportExplained)
            {
                DialogueManager.sentencesQueue.Clear();
                DialogueManager.sentencesQueue.Add("Woah, I seem to have teleported!");
                DialogueManager.teleportExplained = true;
            }
        }
    }
	IEnumerator PlaySound(AudioSource source){
		source.Play();
		yield return new WaitForSeconds(.5f);
		
	}
}
