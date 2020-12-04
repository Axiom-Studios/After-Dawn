using UnityEngine;

public class Player : MonoBehaviour
{
	//Movement variables
	public float walkSpeed;
	public float runSpeed;
	public float jumpForce;
	float speed;
	bool canRun = true;
	bool grounded = true;
	Vector3 keys;

	public float staminaMax;
	public float staminaDrain;
	public float staminaCharge;
	float stamina;

	//Camera variables
	public Camera playerCamera;
	public float camSpeed;
	float horizontalRotation;
	float verticalRotation;
	Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		stamina = staminaMax;
	}

	void Update()
	{
		//Running and Stamina
		if (Input.GetButton("Run") && canRun == true)
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
			speed = walkSpeed;
		}
		if (stamina <= 0)
		{
			canRun = false;
		}
		else if (stamina >= staminaMax)
		{
			canRun = true;
		}
		keys = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		if (!(PauseMenu.paused))
		{
			horizontalRotation += Input.GetAxis("Mouse X") * camSpeed;
			verticalRotation += Input.GetAxis("Mouse Y") * camSpeed;
		}
		verticalRotation = Mathf.Clamp(verticalRotation, -60, 70);
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
		Vector3 movement = velocity * Time.deltaTime;
		rb.MovePosition(transform.position + transform.TransformDirection(movement));
		//Jumping
		if (grounded)
		{
			if (Input.GetButton("Jump") == true)
			{
				rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
			}
		}
	}

	void CameraMovement(float horizontalRotation, float verticalRotation)
	{
		if (verticalRotation < 90 && verticalRotation > -90)
		{
			playerCamera.transform.localRotation = Quaternion.Euler(-verticalRotation, 0, 0);
		}
		transform.localRotation = Quaternion.Euler(0, horizontalRotation, 0);
	}

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
}