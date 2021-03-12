using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumineOrb : MonoBehaviour
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
            Player.walkSpeed += 0.5f;
            transform.Translate(0, -100, 0);
            collected = true;
			source.Play();
			StartCoroutine(PlaySound(source));
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
		yield return new WaitForSeconds(.5f);
	}
}
