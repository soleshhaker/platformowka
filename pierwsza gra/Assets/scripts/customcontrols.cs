using UnityEngine;
using System.Collections;
using System.Collections.Specialized;

[RequireComponent(typeof(Rigidbody))]


public class customcontrols : MonoBehaviour
{
	float currentSpeed = 0f;
	public static float speed = 1500.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public static float jumpHeight = 900.0f;
	private bool grounded = false;
	private float minSpeed = 5f;
	public static float maxspeed = 15.0f;
	private float time = 0;
	public float accelerationTime = 5;


	void Awake()
	{
		GetComponent<Rigidbody>().freezeRotation = true;
	GetComponent<Rigidbody>().useGravity = false;
		
	}

	
	void FixedUpdate()
	{

		
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			
			
			currentSpeed = Mathf.Lerp(minSpeed, maxspeed, time / accelerationTime);
			time += Time.deltaTime;
			//Debug.Log(currentSpeed);
		}
		else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
		{
			currentSpeed = 0;
			time = 0;
			//Debug.Log(currentSpeed);
		}




			// Calculate how fast we should be moving
			Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		targetVelocity = transform.TransformDirection(targetVelocity);
		
		targetVelocity *= speed;
		//Debug.Log(currentSpeed);

		// Apply a force that attempts to reach our target velocity
		Vector3 velocity = GetComponent<Rigidbody>().velocity;
		Vector3 velocityChange = (targetVelocity);
		
		GetComponent<Rigidbody>().AddForce(velocityChange*2, ForceMode.VelocityChange);

		Debug.Log(Input.GetAxis("Horizontal"));


		// Jump
		if (canJump && grounded && Input.GetButton("Jump"))
		{
			GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
		}
		//if (GetComponent<Rigidbody>().velocity.magnitude > maxspeed)
		//{
		//	GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, maxspeed);
		//}

		// We apply gravity manually for more tuning control
		GetComponent<Rigidbody>().AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0));

		grounded = false;
	}

	void OnCollisionStay()
	{
		grounded = true;
	}

	float CalculateJumpVerticalSpeed()
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}
}