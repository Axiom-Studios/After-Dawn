using UnityEngine;

public class CutsceneControl : MonoBehaviour
{
	public GameObject cutscenes;
	public GameObject buttons;
	GameObject currentScene;
	GameObject currentSprite;
	GameObject nextButton;
	GameObject backButton;
	string sceneName;
	bool active;
	int max;
	int currentNum;
	
	void Start(){
		cutscenes.SetActive(false);
		backButton = buttons.transform.GetChild(0).gameObject;
		nextButton = buttons.transform.GetChild(1).gameObject;
	}

	public void Initialize(string name, int length){
		max = length - 1;
		sceneName = name;
		active = true;
		buttons.SetActive(true);
		currentScene = GameObject.Find("/Canvas/Cutscene/" + name);
		currentSprite = currentScene.transform.GetChild (0).gameObject;
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