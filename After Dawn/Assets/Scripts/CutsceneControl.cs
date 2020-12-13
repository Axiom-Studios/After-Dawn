using UnityEngine;
using System.Collections;
public class CutsceneControl : MonoBehaviour
{
	public GameObject sceneSprite;
	
	void Initialize(string name, int length){
		int current = 1;
		while (current < length){
			sceneSprite = GameObject.Find("/Canvas/Cutscenes/snowman/");
		}
	}
}