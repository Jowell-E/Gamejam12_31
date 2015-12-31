using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour {
	public float rotateX;
	public float rotateY;
	public Rigidbody heldObject;
//	public bool holding = false;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		float mouseX = Input.GetAxis ("Mouse X");

		transform.Rotate (0, rotateX * mouseX, 0);

		float mouseY = Input.GetAxis ("Mouse Y");

		Camera.main.transform.Rotate (rotateY * mouseY, 0, 0);

		if (heldObject) {
			heldObject.transform.RotateAround(transform.position,Vector3.up, 45f * Time.deltaTime * mouseX * rotateX);
		}
	}
}
