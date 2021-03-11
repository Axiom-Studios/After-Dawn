using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
	public List<AudioClip> footsteps;
	public AudioSource stepSource;
	public float rate;
	float speed;
	float lastStep;
	

	public List<AudioClip> creepySounds;
	public AudioSource creepySource;
	public float minRate;
	public float maxRate;
	float creepyRate;
	float lastSound;

	void Start(){
		creepyRate = Random.Range(minRate, maxRate);
	}

    // Update is called once per frame
    void Update()
    {
        if (Player.keys != Vector3.zero){
			if ((Time.time - lastStep) >= rate){
				stepSource.clip = footsteps[Random.Range(0, footsteps.Count - 1)];
				stepSource.Play();
				lastStep = Time.time;
			}
		}

		if (Time.time - lastSound >= creepyRate){
			creepySource.clip = creepySounds[Random.Range(0, footsteps.Count - 1)];
			creepySource.Play();
			creepyRate = Random.Range(minRate, maxRate);
			lastSound = Time.time;
		}
    }
}
