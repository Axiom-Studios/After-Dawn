using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumineOrb : MonoBehaviour
{
	AudioSource source;
	void Start(){
		source = gameObject.GetComponent<AudioSource>();
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
			source.Play();
			StartCoroutine(PlaySound(source));
            Player.walkSpeed += 0.75f;
            //Player.runSpeed += 0.5f;
            if (!DialogueManager.lumineExplained)
            {
                DialogueManager.sentencesQueue.Clear();
                DialogueManager.sentencesQueue.Add("Blue orbs make you faster");
                DialogueManager.lumineExplained = true;
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
