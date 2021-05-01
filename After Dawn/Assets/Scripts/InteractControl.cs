using UnityEngine;

public class InteractControl : MonoBehaviour
{
	string InteractName;
	public GameObject map;
	bool mapState = false;


	new Camera camera;
	private void Start()
	{
		camera = GetComponent<Camera>();
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


	//Place functions with the same name as the object you are interacting with here.
	void Box()
	{
		print("You opened a box");
	}
}
