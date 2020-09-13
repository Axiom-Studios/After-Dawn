using UnityEngine;

//USE:
//Floor tags make you grounded
//wall tags make it so you can't jump up them

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
	}

	void Update()
	{
		keys = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

		horizontalRotation += Input.GetAxis("Mouse X") * camSpeed;
		verticalRotation += Input.GetAxis("Mouse Y") * camSpeed;

		//Cursor Lock
		if (Input.GetKeyDown("escape"))
		{
			cursorLocked = !cursorLocked;
		}

		if (cursorLocked == true)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		else if (cursorLocked == false)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
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
		Vector3 movement = velocity * Time.deltaTime;
		rb.velocity = new Vector3(0, rb.velocity.y, 0);
		transform.Translate(movement);

		//Jumping
		if (grounded)
		{
			if (Input.GetKey("space"))
			{
				rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
			}
		}
	}

	void CameraMovement(float horizontalRotation, float verticalRotation)
	{
		if (verticalRotation > 90)
		{
			verticalRotation = 90;
		}
		else if (verticalRotation < -90)
		{
			verticalRotation = -90;
		}
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
