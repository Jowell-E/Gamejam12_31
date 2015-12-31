using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public Transform player;
	NavMeshAgent nav;
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			if (player.GetInstanceID() != other.gameObject.GetInstanceID()) {
				Vector3 objectPos = other.transform.position;
				float distanceSqr = (objectPos - transform.position).sqrMagnitude;
				Vector3 playerPos = other.transform.position;
				float distanceSqrP = (playerPos - transform.position).sqrMagnitude;
				if (distanceSqr <= distanceSqrP) {
					player = other.transform;
				}
			}
		}
	}
	// Update is called once per frame
	void Update () {
		if (player) {
			nav.SetDestination (player.position);
		}
	}
}
