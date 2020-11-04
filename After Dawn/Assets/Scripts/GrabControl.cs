using UnityEngine;

public class GrabControl : MonoBehaviour
{
	new Camera camera;
	public float grabDistance;
	public float throwStartDistance;
	public float throwForce;
	GameObject grabbed;
	Rigidbody grabbedRigidbody;
	bool holding;


	private void Start()
	{
		camera = GetComponent<Camera>();
	}

	void Update()
	{
		Grabbing();
	}

	void Grabbing() //Controls grabbing of grabbable objects
	{
		if (Input.GetButtonUp("Grab"))
		{
			if (!holding)
			{ 
				Ray grab = camera.ScreenPointToRay(Input.mousePosition);
				RaycastHit grabInfo;


				if (Physics.Raycast(grab, out grabInfo, grabDistance))
				{
					if (grabInfo.collider.gameObject.tag == "Grabbable")
					{
						grabbed = grabInfo.collider.gameObject;
						grabbedRigidbody = grabInfo.collider.attachedRigidbody;
						grabbed.SetActive(false);
						grabbed.transform.parent = transform;
						
						holding = true;
					}
				}
			}
			
			else if (holding)
			{
				grabbed.transform.localPosition = new Vector3(0, 0, throwStartDistance);
				grabbed.transform.rotation = transform.rotation;
				grabbed.SetActive(true);
				grabbed.transform.parent = null;
				grabbedRigidbody.velocity = Vector3.zero;
				grabbedRigidbody.angularVelocity = Vector3.zero;
				grabbedRigidbody.AddRelativeForce(Vector3.forward * throwForce);
				holding = false;
			}
		}
	}
}
