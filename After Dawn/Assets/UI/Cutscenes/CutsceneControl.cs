using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneControl : MonoBehaviour
{
	public static bool active = false;
	public static List<Texture> textures;
	public static int imageNum;
	public static RawImage cutsceneImage;
	public static Color shown = new Color(1, 1, 1, 1);
	public static int length;
	public static GameObject buttons;
	Color blank = new Color(0, 0, 0, 0);

	void Start(){
		buttons = GameObject.Find("Buttons");
		cutsceneImage = GetComponent<RawImage>();
		cutsceneImage.color = blank;
		buttons.SetActive(false);
	}

	void Update(){
	}

	public static void Initialize(List<Texture> textureList, int cutsceneLength){
		active = true;
		textures = textureList;
		length = cutsceneLength;
		cutsceneImage.color = shown;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		buttons.SetActive(true);
	}


	public void Next(){
		if (imageNum < length - 1){
			imageNum += 1;
			cutsceneImage.texture = textures[imageNum];
		}
		else{
			active = false;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			cutsceneImage.color = blank;
			buttons.SetActive(false);
		}
	}

	public void Back(){
		if (imageNum > 0){
			imageNum -= 1;
			cutsceneImage.texture = textures[imageNum];
		}
	}
}
