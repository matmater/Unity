using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float turn;
	public float AscDesc;

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

		Vector3 movement = new Vector3 (moveHorizontal, AscDesc * heightAdjustment, moveVertical);
		rb.AddRelativeForce (movement * speed);
		rb.AddRelativeTorque (Vector3.up * turnShip * turn);

		if (Input.GetKeyDown ("space")) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f, Screen.height*0.5f, 0.0f));
			Physics.Raycast (ray, out hit, 500);
			Debug.DrawLine(ray.origin, hit.point, Color.green, 2, false);
			print ("pew!");
			//hit.transform.SendMessage ("Hit");
		}
	
	}
}