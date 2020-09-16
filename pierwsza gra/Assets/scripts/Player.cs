using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]


public class Player : MonoBehaviour
{

	public static float speed = 12.0f;
	private float gravity = 10.0f;
	private float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public Animator animator;
	public static float jumpHeight = 2.0f;
	private bool grounded = false;
	private float horizontal;
	private float vertical;
	Vector3 targetVelocity;
	private Rigidbody rigidbody;
	int i;
	float countDown;
	AudioSource source;

	public static int speedpotion, score, bluedust, jumppotion, jump, key;

	void OnTriggerEnter(Collider col)
	{
		source = GameObject.Find("coinsound").GetComponent<AudioSource>();
		if (col.gameObject.name == "GoldCoin")
		{
			Destroy(col.transform.parent.gameObject);
			score += 20;
			source.Play();
		}
	}
	void Awake()
	{
		GetComponent<Rigidbody>().freezeRotation = true;
		GetComponent<Rigidbody>().useGravity = false;
		
		
		rigidbody = GetComponent<Rigidbody>();

		PlayerPrefs.GetInt("speedpotion", speedpotion);
		PlayerPrefs.GetInt("score", score);
		PlayerPrefs.GetInt("bluedust", bluedust);
		PlayerPrefs.GetInt("jumppotion", jumppotion);
		PlayerPrefs.GetInt("jump", jump);
		PlayerPrefs.GetInt("key", key);
		

	}
	void OnDestroy()
	{
		PlayerPrefs.SetInt("speedpotion", speedpotion);
		PlayerPrefs.SetInt("score", score);
		PlayerPrefs.SetInt("bluedust", bluedust);
		PlayerPrefs.SetInt("jumppotion", jumppotion);
		PlayerPrefs.SetInt("jump", jump);
		PlayerPrefs.SetInt("key", key);
		PlayerPrefs.Save();
	}
	void Update()
    {
		//Debug.Log(jump);
		
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
		Vector3 velocity = rigidbody.velocity;
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
		//Debug.Log(targetVelocity);
		// Jump
		if (canJump && grounded && Input.GetButton("Jump"))
			{
				rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
			}
		

		// We apply gravity manually for more tuning control
		rigidbody.AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0));

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
		return Mathf.Sqrt(2 * (jumpHeight + jump) * gravity);
	}



}