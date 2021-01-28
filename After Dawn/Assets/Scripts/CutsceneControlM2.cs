using System.Collections.Generic;
using UnityEngine;

public class CutsceneControlM2 : MonoBehaviour
{
	public static Transform currentSprite;
	public static GameObject currentScene;
	public static GameObject cutscenes;
	public static int currentNum = 0;
	// Start is called before the first frame update
	void Start()
	{
		cutscenes = GameObject.Find("/Canvas/Cutscenes");
		cutscenes.SetActive(false);
	}

	public static void Cutscene(string name, int length){
		cutscenes.SetActive(true);
		currentScene = GameObject.Find("/Canvas/Cutscenes/" + name);
		currentScene.SetActive(true);
		currentSprite = currentScene.transform.GetChild(currentNum);
		currentSprite.transform.position = Vector3.forward;
	}
	public void Next(){
		currentSprite.transform.position = Vector3.zero;
		currentNum += 1;
		currentSprite = currentScene.transform.GetChild(currentNum);
	}
	public void Back(){
		currentSprite.transform.position = Vector3.zero;
		currentNum -= 1;
		currentSprite = currentScene.transform.GetChild(currentNum);
	}
}