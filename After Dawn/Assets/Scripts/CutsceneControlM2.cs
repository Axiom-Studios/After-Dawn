﻿using System.Collections.Generic;
using UnityEngine;

public class CutsceneControlM2 : MonoBehaviour
{
	public static Transform currentSprite;
	public static GameObject currentScene;
	public static GameObject cutscenes;
	public static int currentNum;
    // Start is called before the first frame update
    void Start()
    {
		cutscenes = GameObject.Find("/Canvas/Cutscenes");
        cutscenes.SetActive(false);
    }

    public static void InitializeCutscene(string name, int length){
		cutscenes.SetActive(true);
		currentScene = GameObject.Find("/Canvas/Cutscenes/" + name);
	}
}

