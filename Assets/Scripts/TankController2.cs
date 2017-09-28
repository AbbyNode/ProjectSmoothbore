﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController2 : MonoBehaviour {

	public float maxSpeed = 1;
	public float rotationSpeed = 90; // Degrees per second

	private Rigidbody2D rb;

	void Start() {
		rb = this.GetComponent<Rigidbody2D>();
	}

	void Update() {
		Vector3 inputMove = Vector3.zero;
		inputMove.x = Input.GetAxis("Horizontal");
		inputMove.y = Input.GetAxis("Vertical");

		// Move

		if (inputMove != Vector3.zero) {
			// Input angle, clamped between 0 and 360
			float inputAngle = (Mathf.Atan2(inputMove.y, inputMove.x) * Mathf.Rad2Deg);
			while (inputAngle < 0) {
				inputAngle += 360;
			}

			float currentAngle = transform.eulerAngles.z;

			// Angle diff, soft clamped between -180 and 180
			float angleDiff = inputAngle - currentAngle;
			if (angleDiff < -180) {
				angleDiff += 360;
			} else if (angleDiff > 180) {
				angleDiff -= 360;
			}

			float rotateAmt = Time.deltaTime * rotationSpeed;
			if (angleDiff < 0) {
				rotateAmt *= -1;
				rotateAmt = Mathf.Max(rotateAmt, angleDiff);
			} else { // angleDiff > 0
				rotateAmt = Mathf.Min(rotateAmt, angleDiff);
			}

			transform.eulerAngles = new Vector3(0, 0, currentAngle + rotateAmt);
		}
	}

}
