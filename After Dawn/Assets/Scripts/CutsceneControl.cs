using UnityEngine;
using System.Collections;
public class CutsceneControl : MonoBehaviour
{
	GameObject sceneSprite;
	
	void Start(){
		sceneSprite = GameObject.Find("/Canvas/Cutscenes");
		sceneSprite.SetActive(false);
	}
	void Initialize(string name, int length){
		int current = 1;
		while (current < length){
			sceneSprite = GameObject.Find("/Canvas/Cutscenes/snowmen/");
			sceneSprite.SetActive(false);
		}
	}
}