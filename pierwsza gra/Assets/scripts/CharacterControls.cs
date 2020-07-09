using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]


public class CharacterControls : MonoBehaviour
{

	public static float speed = 12.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	Animator animator;
	public static float jumpHeight = 2.0f;
	private bool grounded = false;
	private bool looksright = false;
	private bool looksleft = false;


	void Awake()
	{
		GetComponent<Rigidbody>().freezeRotation = true;
		GetComponent<Rigidbody>().useGravity = false;
		animator = GetComponent<Animator>();
	}
	void Update()
    {
		Debug.Log(looksleft);
		if(transform.eulerAngles.y == 90)
        {
			looksright = true;
			looksleft = false;
		}
		if (transform.eulerAngles.y != 90)
		{
			looksright = false;
			looksleft = true;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) && looksright || Input.GetKeyDown(KeyCode.RightArrow) && looksleft)
		{
			Quaternion originalRot = transform.rotation;
			transform.rotation = originalRot * Quaternion.Euler(0, 180, 0);
		}
	}
	void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
		bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
		bool isWalking = hasHorizontalInput || hasVerticalInput;
		animator.SetBool("iswalking", isWalking);

		
		// Calculate how fast we should be moving
		Vector3 targetVelocity = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;

			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = GetComponent<Rigidbody>().velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);

			// Jump
			if (canJump && grounded && Input.GetButton("Jump"))
			{
				GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
			}
		

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