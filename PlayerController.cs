using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float turn;
	public float ascDesc;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		//define in input manager !!
		float turnShip = Input.GetAxis ("Turning");
		float heightAdjustment = Input.GetAxis ("Height");

		Vector3 movement = new Vector3 (moveHorizontal, ascDesc * heightAdjustment, moveVertical);

		rb.AddRelativeForce (movement * speed);
		rb.AddRelativeTorque (Vector3.up * turnShip * turn);
	
	}
}