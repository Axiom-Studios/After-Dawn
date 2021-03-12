using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public GameObject slider;
	Slider sprint;

	//Movement variables
	public static float walkSpeed = 5f;
	//public static float runSpeed = 5f;
	//public float jumpForce;
	float speed = 5f;
	//bool canRun = true;
	//bool grounded = true;
	public static Vector3 keys;

	/*public float staminaMax;
	public float staminaDrain;
	public float staminaCharge;
	float stamina;*/

	//Camera variables
	public Camera playerCamera;
	public static bool passed = false;
	public float camSpeed;
	float horizontalRotation;
	float verticalRotation;
	Rigidbody rb;

	//Other Variables
	public static bool hasKey = false;
	public static bool gameWon = false;
	public GameObject darkness;
	public GameObject endText;
	public GameObject secretEnding;
	private bool sleeping = false;
	public Vector3 spawn = new Vector3(20, 10, -30);
	public static int beacons = 0;
	public GameObject beaconPrefab;
	bool mouseLearned = false;
	bool wasdLearned = false;
	public static bool safeZoned = false;

	private void Start()
	{
		walkSpeed = 5f;
		speed = 5f;
		beacons = 0;
		hasKey = false;
		gameWon = false;
		//sprint = slider.GetComponent<Slider>();
		//sprint.maxValue = staminaMax;
		rb = GetComponent<Rigidbody>();
		//stamina = staminaMax;
		darkness.SetActive(false);
	}

	void Update()
	{
		// movement tutorial dialogue
		if (horizontalRotation != 0f || verticalRotation != 0f)
		{
			mouseLearned = true;
		}
		if (Time.time >= 10 && !mouseLearned)
		{
			DialogueManager.sentencesQueue.Add("Use mouse to look around.");
			mouseLearned = true;
		}

		if (keys != Vector3.zero)
		{
			wasdLearned = true;
		}
		if (Time.time >= 20 && !wasdLearned)
		{
			DialogueManager.sentencesQueue.Add("Use WASD to move.");
			wasdLearned = true;
		}
		//sprint.value = stamina;
		if (DayNightCycle.night)
		{
			hasKey = false;
			sleeping = true;
			darkness.SetActive(true);
		}
		else
		{
			if (sleeping)
			{
				transform.position = spawn;
				sleeping = false;
				passed = false;
			}
			darkness.SetActive(false);
		}
		//Running and Stamina
		/*if (Input.GetButton("Run") && canRun == true)
		{
			stamina -= staminaDrain * Time.deltaTime;
			speed = runSpeed;
		}
		else
		{
			if (stamina < staminaMax)
			{
				stamina += staminaCharge * Time.deltaTime;
			}
			
		}
		if (stamina <= 0)
		{
			canRun = false;
		}
		else if (stamina >= staminaMax)
		{
			canRun = true;
		}*/
		speed = walkSpeed;
		keys = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		if (!(PauseMenu.paused) && !(CutsceneControl.active))
		{
			horizontalRotation += Input.GetAxis("Mouse X") * camSpeed;
			verticalRotation += Input.GetAxis("Mouse Y") * camSpeed;
		}
		verticalRotation = Mathf.Clamp(verticalRotation, -60, 70);
		if (beacons > 0 && Input.GetButtonDown("Fire2"))
		{
			Instantiate(beaconPrefab, transform.position, transform.rotation);
			beacons -= 1;
		}
	}
	void FixedUpdate()
	{
		if (SkyOrb.skyActive) 
		{
			rb.velocity = Vector3.zero;
			transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
		else
		{
			PlayerMovement(keys);
			CameraMovement(horizontalRotation, verticalRotation);
		}
	}

	void PlayerMovement(Vector3 input)
	{
		//X and Z movement
		Vector3 direction = input.normalized;
		Vector3 velocity = direction * speed;
		rb.velocity = transform.TransformDirection(velocity) + (Vector3.up * rb.velocity.y);
		//Jumping
		/*if (Input.GetButton("Jump") == true)
		{
			if (grounded)
			{
				rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
			}
		}*/
	}

	void CameraMovement(float horizontalRotation, float verticalRotation)
	{
		if (verticalRotation < 90 && verticalRotation > -90)
		{
			playerCamera.transform.localRotation = Quaternion.Euler(-verticalRotation, 0, 0);
		}
		transform.localRotation = Quaternion.Euler(0, horizontalRotation, 0);
	}

	/*
	private void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.tag != "Wall")
		{
			grounded = true;
		}
		else if (collision.gameObject.tag == "Wall")
		{
			grounded = false;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag != "wall")
		{
			grounded = false;
		}
	}
	*/
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Camp") && hasKey)
		{
			if (DayNightCycle.day > 3)
			{
				Cursor.lockState = CursorLockMode.None;
            	Cursor.visible = true;
				gameWon = true;
				if (DialogueManager.orbs == 51)
				{
					secretEnding.SetActive(true);
				}
            	else
				{
					endText.SetActive(true);
				}
            	Time.timeScale = 0f;
            	PauseMenu.paused = true;	
			}
			passed = true;
			DayNightCycle.sunset = Time.time;
			hasKey = false;
		}

		if (other.gameObject.CompareTag("Safe Zone"))
		{
			safeZoned = true;
		}
		/*if (other.gameObject.CompareTag("Key"))
		{
			Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
			gameWon = true;
            endText.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.paused = true;
		}
		*/
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Safe Zone"))
		{
			safeZoned = false;
		}
	}
}