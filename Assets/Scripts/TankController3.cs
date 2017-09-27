using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController3 : MonoBehaviour {

	public float maxSpeed = 1;
	public float rotationSpeed = 1;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start() {
		rb = this.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update() {


		float hMove = Input.GetAxis("Horizontal");
		float vMove = Input.GetAxis("Vertical");

		Vector3 move = Vector3.zero;
		move.x = hMove;
		move.y = vMove;

		// Move

		if (move != Vector3.zero) {
			Vector3 dir = move;
			float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

}
