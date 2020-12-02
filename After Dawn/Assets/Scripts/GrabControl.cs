using UnityEngine;

public class GrabControl : MonoBehaviour
{
	new Camera camera;
	public float grabDistance;
	public float throwStartDistance;
	float throwPrepTime;
	float throwPrepStart;
	public float timeIncrease;
	bool throwPrep = false;
	GameObject grabbed;
	Rigidbody grabbedRigidbody;
	bool holding;


	private void Start() {
		camera = GetComponent<Camera>();
	}

	void Update() {
		Grabbing();
	}

	void Grabbing() //Controls grabbing of grabbable objects
	{
		if (Input.GetButtonUp("Grab")) {
			if (!holding){ 
				Ray grab = camera.ScreenPointToRay(Input.mousePosition);
				RaycastHit grabInfo;
				throwPrepTime = 0;
				if (Physics.Raycast(grab, out grabInfo, grabDistance)) {
					if (grabInfo.collider.gameObject.tag == "Grabbable") {
						grabbed = grabInfo.collider.gameObject;
						grabbedRigidbody = grabInfo.collider.attachedRigidbody;
						grabbed.SetActive(false);
						grabbed.transform.parent = transform;
						holding = true;
					}
				}
			}
		}
		if (Input.GetButton("Throw")) {
			if (holding) {
				if (!throwPrep) {
					throwPrepStart = Time.realtimeSinceStartup;
					throwPrep = true;
				}
				else if (throwPrep) {
					throwPrepTime += Time.realtimeSinceStartup - throwPrepStart;
					throwPrepTime = Mathf.Clamp(throwPrepTime, 0f, 300f / timeIncrease);
					Debug.Log(throwPrepTime);
				}
			}
		}
		if (Input.GetButtonUp("Throw")) {
			throwPrep = false;
			grabbed.transform.localPosition = new Vector3(0, 0, throwStartDistance);
			grabbed.transform.rotation = transform.rotation;
			grabbed.SetActive(true);
			grabbed.transform.parent = null;
			grabbedRigidbody.velocity = Vector3.zero;
			grabbedRigidbody.angularVelocity = Vector3.zero;
			grabbedRigidbody.AddRelativeForce(Vector3.forward * (throwPrepTime * timeIncrease));
			holding = false;
		}
	}
}