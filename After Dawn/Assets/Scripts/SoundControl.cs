using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
	public List<AudioClip> footsteps;
	public float rate;
	float speed;
	float lastStep = 0;
	public AudioSource stepSource;

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
    }
}
