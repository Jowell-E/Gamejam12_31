using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public string holdButton;
	public float grabDistance;
	public float slowedSpeed;
	public float health = 100f;

	private Camera cam;
	private MouseMove camMove;
	private Movement movement;
	private float originalSpeed;
	private float originalSpeedR;

	// Use this for initialization
	void Start () {
		cam = GetComponentInChildren<Camera> ();
		camMove = GetComponent<MouseMove> ();
		movement = GetComponent<Movement> ();
		originalSpeed = movement.movementSpeed;
		originalSpeedR = camMove.rotateX;
	}

	void HoldObject(Rigidbody target){
		movement.movementSpeed = slowedSpeed;
		movement.holding = true;
		movement.heldObject = target;
		camMove.heldObject = target;
		camMove.rotateX = slowedSpeed;
	}
	void LetGo(){
		movement.movementSpeed = originalSpeed;
		movement.heldObject = null;
		camMove.rotateX = originalSpeedR;
		camMove.heldObject = null;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButton (holdButton)) {
			RaycastHit hit;
			if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, grabDistance)) {
				if (hit.transform.CompareTag ("Movable")) {
					HoldObject (hit.transform.GetComponent<Rigidbody> ());
				}
			}
		} else {
			LetGo ();
		}
	}

	public void Hit(float damage){
		health -= damage;

		if (health <= 0) {
			Die ();
		}
	}

	void Die(){
		Destroy (this.gameObject);
	}
}
