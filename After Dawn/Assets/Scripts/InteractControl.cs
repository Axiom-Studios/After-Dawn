using UnityEngine;
using System.Collections.Generic;

public class InteractControl : MonoBehaviour
{
	string InteractName;
	public GameObject map;
	public static List<Vector2> beacons;
	Texture2D mapTexture;
	public static bool mapState = false;
	


	new Camera camera;
	private void Start()
	{
		camera = GetComponent<Camera>();
		mapTexture = map.GetComponent<Texture2D>();
	}

	void Update()
	{
		Interaction();
	}

	void Interaction() //Controls calling of interaction functions
	{
		map.SetActive(mapState);
		if (Input.GetButtonDown("Interact"))
		{
			mapState = !mapState;
			foreach (Vector2 beacon in beacons){
				circleSimple(beacon.x, beacon.y, 10, new Color(255,255,255), mapTexture);
			}
			/*
			Ray interact = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit interactInfo;

			if (Physics.Raycast(interact, out interactInfo, 5))
			{
				if (interactInfo.collider.gameObject.tag == "Interactable")
				{
					InteractName = interactInfo.collider.gameObject.name;
					Invoke(InteractName, 0);
				}
			}*/
		}
	}



	public void circleSimple(float xCenter, float yCenter, float radius, Color c, Texture2D texture)
    {
        float x, y, r2;
        
        r2 = radius * radius;
        for (x = -radius; x <= radius; x++) {
            y = (int) (Mathf.Sqrt(r2 - x*x) + 0.5);
            texture.SetPixel((int) xCenter + (int) x, (int) yCenter + (int) y, c);
            texture.SetPixel((int) xCenter + (int) x, (int) yCenter - (int) y, c);
        }
    }


	//Place functions with the same name as the object you are interacting with here.
	void Box()
	{
		print("You opened a box");
	}
}
