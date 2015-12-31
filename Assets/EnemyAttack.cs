using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public float attackDamage = 10f;
	private float timer = 0f;
	public float attackDelay = 5f; 

	public bool inRange = false;
	private EnemyMovement movement;
//	private Animator anim;
	// Use this for initialization
	void Start () {
//		anim = GetComponent<Animator> ();
		movement = GetComponent<EnemyMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= attackDelay) {
			Attack ();
		}
	}

	void OnTriggerEnter(Collider other){
		if (movement.player) {
			if (other.transform.GetInstanceID () == movement.player.GetInstanceID ()) {
				inRange = true;
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (movement.player) {
			if (other.transform.GetInstanceID () == movement.player.GetInstanceID ()) {
				inRange = false;
			}
		}
	}
	void Attack(){
//		anim
		timer = 0f;
		if (inRange) {
			movement.player.GetComponent<PlayerController> ().Hit (attackDamage);
		}
	}
}
