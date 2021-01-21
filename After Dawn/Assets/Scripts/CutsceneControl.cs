using UnityEngine;
using System.Collections.Generic;
public class CutsceneControl : MonoBehaviour
{
	//public static Initialize variables
	public static int max;
	//public static GameObject buttons;
	public static GameObject currentScene;
	public static GameObject currentSprite;


	//Other variables
	public static GameObject cutscenes;
	GameObject nextButton;
	GameObject backButton;
	public static int currentNum;
	
	void Start(){
		//buttons = GameObject.Find("/Canvas/Cutscenes/Buttons");
		cutscenes.SetActive(false);
	}

	public static void Initialize(string name, int length){
		max = length - 1;
		currentNum = 0;
		cutscenes.SetActive(true);
		//buttons.SetActive(true);
		currentScene = GameObject.Find("Snowmen");
		currentSprite = GameObject.Find("1"); //currentScene.transform.GetChild(0).gameObject;
		currentSprite.SetActive(true);
	}

	public void Next(){
		
	}

	public void Back(){
		
	}
}