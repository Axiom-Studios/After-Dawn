using UnityEngine;

public class CutsceneControl : MonoBehaviour
{
	//public static Initialize variables
	public static int max;
	public static GameObject buttons;
	public static GameObject currentScene;
	public static GameObject currentSprite;


	//Other variables
	public GameObject cutscenes;
	GameObject nextButton;
	GameObject backButton;
	public static int currentNum;
	
	void Start(){
		buttons = GameObject.Find("/Canvas/Cutscenes/Buttons");
		//cutscenes.SetActive(false);
		backButton = buttons.transform.GetChild(0).gameObject;
		nextButton = buttons.transform.GetChild(1).gameObject;
	}

	public static void Initialize(string name, int length){
		max = length - 1;
		currentNum = 0;
		buttons.SetActive(true);
		currentScene = GameObject.Find("Snowmen");
		currentSprite = GameObject.Find("1"); //currentScene.transform.GetChild(0).gameObject;
		currentSprite.SetActive(true);
	}

	public void Next(){
		currentNum += 1;
		currentSprite.SetActive(false);
		currentSprite = currentScene.transform.GetChild(currentNum).gameObject;
		currentSprite.SetActive(true);
		if (currentNum == max){
			nextButton.SetActive(false);
		}
		else if (currentNum == 1){
			backButton.SetActive(true);
		}
	}

	public void Back(){
		currentNum -= 1;
		currentSprite.SetActive(false);
		currentSprite = currentScene.transform.GetChild(currentNum).gameObject;
		currentSprite.SetActive(true);
		if (currentNum == 0){
			backButton.SetActive(false);
		}
		else if (currentNum == max - 1){
			nextButton.SetActive(true);
		}
	}
}