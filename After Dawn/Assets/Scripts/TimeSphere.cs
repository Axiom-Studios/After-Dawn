using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSphere : MonoBehaviour
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

    public float timeAdded;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
			source.Play();
			StartCoroutine(PlaySound(source));
            //when coliding with player, add time to the day and destroy the sphere.
            DayNightCycle.sunset += timeAdded;
            if (!DialogueManager.timeExplained)
            {
                DialogueManager.sentencesQueue.Clear();
                DialogueManager.sentencesQueue.Add("White orbs push back the island\'s time a bit");
                DialogueManager.timeExplained = true;
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
