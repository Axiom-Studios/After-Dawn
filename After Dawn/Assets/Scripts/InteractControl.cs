using UnityEngine;
public class InteractControl : MonoBehaviour
{
	string InteractName;
	new Camera camera;

	void Start(){
		camera = GetComponent<Camera>();
	}

	void Update(){
		Interaction();
	}

	public void Interaction(){ //Controls calling of interaction functions
		if (Input.GetButtonDown("Interact")){
			Ray interact = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit interactInfo;

			if (Physics.Raycast(interact, out interactInfo, 5)){
				if (interactInfo.collider.gameObject.tag == "Interactable"){
					InteractName = interactInfo.collider.gameObject.name;
					Invoke(InteractName, 0);
				}
			}
		}
	}


	//Place functions with the same name as the object you are interacting with here.
	void Box()
	{
		print("You opened a box");
	}

	void Snowmans(){
		CutsceneControl.Initialize("Snowmen", 3);
	}
}
