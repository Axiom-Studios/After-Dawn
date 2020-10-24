using UnityEngine;

public class GrabControl : MonoBehaviour
{
	new Camera camera;
	private void Start()
	{
		camera = GetComponent<Camera>();
	}

	void Update()
	{
		Grabbing();
	}

	void Grabbing() //Controls calling of interaction functions
	{
		if (Input.GetButtonDown("Interact"))
		{
			Ray grab = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit grabInfo;

			if (Physics.Raycast(grab, out grabInfo, 5))
			{
				if (grabInfo.collider.gameObject.tag == "Grabbable")
				{
					grabInfo.collider.gameObject.SetActive(false);
					grabInfo.collider
	= transform.position - Vector3.down;
				}
			}
		}
	}
}
