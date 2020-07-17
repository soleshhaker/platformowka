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
	public float horizontal;
	public float vertical;
	Vector3 targetVelocity;
	public float tenSec = 10;
	public bool timerRunning = true;
	int i;
	float countDown;
	void Awake()
	{
		GetComponent<Rigidbody>().freezeRotation = true;
		GetComponent<Rigidbody>().useGravity = false;
		animator = GetComponent<Animator>();
	}
	void Update()
    {
		targetVelocity = new Vector3(vertical, 0, horizontal);
		targetVelocity = transform.TransformDirection(targetVelocity);
		targetVelocity *= speed;
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.rotation = Quaternion.Euler(0, 90, 0);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.rotation = Quaternion.Euler(0, -90, 0);
			targetVelocity[0] = targetVelocity[0] * -1;
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{

			StartCoroutine(StartCounter());
		}

	}
	private IEnumerator StartCounter()
	{
		countDown = 0.15f;
		for (int i = 0; i < 10000; i++)
		{
			while (countDown >= 0)
			{
				targetVelocity[0] = targetVelocity[0] * -1;
				countDown -= Time.smoothDeltaTime;
				yield return null;
			}
		}
	}
		void FixedUpdate()
	{
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
		bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
		bool isWalking = hasHorizontalInput || hasVerticalInput;
		animator.SetBool("iswalking", isWalking);


		// Apply a force that attempts to reach our target velocity
		Vector3 velocity = GetComponent<Rigidbody>().velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);
		//Debug.Log(targetVelocity);
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
		return Mathf.Sqrt(2 * (jumpHeight + playeritems.Jump) * gravity);
	}
}