using UnityEngine;

public class CutsceneControl : MonoBehaviour
{
	public GameObject cutscenes;
	GameObject currentScene;
	GameObject currentSprite;
	string sceneName;
	bool active;
	int max;
	int currentNum = 1;
	
	void Start(){
		cutscenes.SetActive(false);
	}

	void Initialize(string name, int length){
		max = length;
		sceneName = name;
		active = true;
		cutscenes.SetActive(true);
		currentScene = GameObject.Find("/Canvas/Cutscene/" + name);
		
	}

	void Next(){
		if (active){
			
		}
	}
}