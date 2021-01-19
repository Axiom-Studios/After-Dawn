using UnityEngine;
using System.Collections.Generic;
public class CutsceneControl : MonoBehaviour
{
<<<<<<< Updated upstream
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
		backButton = buttons.transform.GetChild(0).gameObject;
		nextButton = buttons.transform.GetChild(1).gameObject;
	}

	public static void Initialize(string name, int length){
		max = length - 1;
		currentNum = 0;
		cutscenes.SetActive(true);
		//buttons.SetActive(true);
		currentScene = GameObject.Find("Snowmen");
		currentSprite = GameObject.Find("1"); //currentScene.transform.GetChild(0).gameObject;
		currentSprite.SetActive(true);
=======
	//Predifined GameObjects (set unactive at start)
	List<GameObject> scenes = new List<GameObject>();
	public static Dictionary<string, List<GameObject>> sprites = new Dictionary<string, List<GameObject>>();
	public static GameObject buttons;
	public static List<GameObject> currentSprites = new List<GameObject>();
	public static GameObject currentScene;
	public GameObject cutscenes;
	
	void Start(){
		buttons = GameObject.Find("Buttons");
		for (int i = 0; i < cutscenes.transform.childCount; i++){ //Get list of scenes
			scenes.Add(cutscenes.transform.GetChild(i).gameObject);
		}
		foreach (GameObject scene in scenes){ //loop once for each scene
			List<GameObject> spriteList = new List<GameObject>();
			for (int i = 0; i < scene.transform.childCount - 1; i++){
				spriteList.Add(scene.transform.GetChild(i).gameObject);
			}
			sprites.Add(scene.gameObject.name, spriteList);
		}
	}

	public static void Initialize(string name, int length){
		currentSprites = sprites[name];
		for (int i = 0; i < currentSprites.Count; i++){
			if (currentSprites[i].name == name){
				Debug.Log(currentSprites[i].name);
				currentScene = currentSprites[i];
				break;
			}
		}
		currentScene.SetActive(true);
		foreach (GameObject sprite in currentSprites){
			sprite.SetActive(true);
			print(sprite.name);
		}
>>>>>>> Stashed changes
	}

	public void Next(){
		
	}

	public void Back(){
		
	}
}