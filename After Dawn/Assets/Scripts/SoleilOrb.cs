using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoleilOrb : MonoBehaviour
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
			source.Play();
			StartCoroutine(PlaySound(source));
            DayNightCycle.dayLength += 20f;
            DayNightCycle.sunset += 20f;
            DayNightCycle.initialSunset += 20f;
            if (!DialogueManager.soleilExplained)
            {
                DialogueManager.sentencesQueue.Clear();
                DialogueManager.sentencesQueue.Add("Orange orbs make the day a bit longer");
                DialogueManager.soleilExplained = true;
            }
        }
    }
	IEnumerator PlaySound(AudioSource source){
		source.Play();
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		yield return new WaitForSeconds(.5f);
		transform.Translate(0, -100, 0);
        collected = true;
	}
}
