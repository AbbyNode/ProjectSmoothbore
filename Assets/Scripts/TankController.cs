using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankController : MonoBehaviour {
	public float maxSpeed = 8; // Units per second
	public float rotationSpeed = 180; // Degrees per second
	public int controllerNumber;

	private EventManager em;
	private UnityEvent moveEvent;

	private Rigidbody2D rb;

    private string hMove;
    private string vMove;

	void Start() {
		em = GlobalManager.FindPlayerEventManager(this.transform);
		moveEvent = em.GetEvent("move");
        hMove = "P" + controllerNumber + "Horizontal";
        vMove = "P" + controllerNumber + "Vertical";

        rb = this.GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0;

		Vector2 inputMove = Vector2.zero;
		inputMove.x = Input.GetAxis(hMove);
		inputMove.y = Input.GetAxis(vMove);

		if (inputMove != Vector2.zero) {
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
			} else if (angleDiff == 180) { // Prefer clockwise full turns;
				angleDiff = -180;
			}

			// Rotate if needed
			if (angleDiff != 0) {
				float rotateAmt = Time.deltaTime * rotationSpeed; // Usual rotate amt
				if (angleDiff < 0) {
					rotateAmt *= -1;
					rotateAmt = Mathf.Max(rotateAmt, angleDiff); // Clamp with angleDiff
				} else { // angleDiff > 0
					rotateAmt = Mathf.Min(rotateAmt, angleDiff); // Clamp with angleDiff
				}
				transform.eulerAngles = new Vector3(0, 0, currentAngle + rotateAmt); // Add to rotation
			}

			// Move
			if (Input.GetAxisRaw("Anchor") == 0) { // Not anchored
				float moveAmt = Time.deltaTime * maxSpeed; // Usual move amt
				moveAmt *= ((180 - Mathf.Abs(angleDiff)) / 180); // Reduce if facing away

				Vector3 moveVec3 = transform.right * moveAmt;
				Vector2 moveVec2 = rb.position + (new Vector2(moveVec3.x, moveVec3.y));
				rb.MovePosition(moveVec2);
				
				moveEvent.Invoke();
			}
		}
	}
}
