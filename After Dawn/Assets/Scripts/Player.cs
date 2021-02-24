﻿using UnityEngine;
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
	Vector3 keys;

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
	public GameObject startText;
	private bool sleeping = false;
	public Vector3 spawn = new Vector3(126, 4, -140);
	public static int beacons = 0;
	public GameObject beaconPrefab;
	public static int timeExplained = 0;
	public static int soleilExplained = 0;
	public static int lumineExplained = 0;
	public static int stellarExplained = 0;
	public GameObject timeText;
	public GameObject soleilText;
	public GameObject lumineText;
	public GameObject stellarText;

	private void Start()
	{
		//sprint = slider.GetComponent<Slider>();
		//sprint.maxValue = staminaMax;
		rb = GetComponent<Rigidbody>();
		//stamina = staminaMax;
		darkness.SetActive(false);
		Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        startText.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.paused = true;
	}

	void Update()
	{
		if (timeExplained == 1)
		{
			timeText.SetActive(true);
			timeExplained = 2;
			Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            PauseMenu.paused = true;
		}
		if (soleilExplained == 1)
		{
			soleilText.SetActive(true);
			soleilExplained = 2;
			Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            PauseMenu.paused = true;
		}
		if (lumineExplained == 1)
		{
			lumineText.SetActive(true);
			lumineExplained = 2;
			Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            PauseMenu.paused = true;
		}
		if (stellarExplained == 1)
		{
			stellarText.SetActive(true);
			stellarExplained = 2;
			Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            PauseMenu.paused = true;
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
		if (!(PauseMenu.paused))
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
		CameraMovement(horizontalRotation, verticalRotation);
		PlayerMovement(keys);
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
			if (DayNightCycle.day == 3)
			{
				Cursor.lockState = CursorLockMode.None;
            	Cursor.visible = true;
				gameWon = true;
            	endText.SetActive(true);
            	Time.timeScale = 0f;
            	PauseMenu.paused = true;	
			}
			passed = true;
			DayNightCycle.sunset = Time.time;
			hasKey = false;
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
}