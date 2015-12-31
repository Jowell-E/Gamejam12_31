using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float movementSpeed;
	public float jumpVelocity;
	public string sideways;
	public string forward;
	public string jumpButton;
	public bool holding = false;
	public Rigidbody heldObject;

	Rigidbody rb;
	CharacterController cc;
	public bool grounded = true;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Ground")) {
			grounded = true;
		}
	}
	void FixedUpdate(){
		float moveX = Input.GetAxis (sideways)  * movementSpeed;
		float moveY = Input.GetAxis (forward)  * movementSpeed;


		Vector3 speed = new Vector3 (moveX, rb.velocity.y, moveY);

		rb.velocity = transform.rotation * speed;
		if (heldObject) {
			speed = new Vector3 (moveX, heldObject.velocity.y, moveY);
			heldObject.velocity = heldObject.transform.rotation * speed;
		}

		if (grounded) {
			if (Input.GetButton (jumpButton)) {
				grounded = false;
				rb.velocity = new Vector3 (rb.velocity.x, jumpVelocity, rb.velocity.z);
			}
		}
	}
}
