using UnityEngine;

public class Player : MonoBehaviour
{
	//Movement variables
	public float speed;
	public float jumpForce;
	bool grounded = true;
	Vector3 keys;

	//Camera variables
	public Camera camera;
	public float camSpeed;
	float horizontalRotation;
	float verticalRotation;
	bool cursorLocked = true;
	Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
	{
		keys = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		horizontalRotation += Input.GetAxis("Mouse X") * camSpeed;
		verticalRotation += Input.GetAxis("Mouse Y") * camSpeed;
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
			camera.transform.localRotation = Quaternion.Euler(-verticalRotation, 0, 0);
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
