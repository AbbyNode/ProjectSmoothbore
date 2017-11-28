using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	public PlayerManager playerM;

	private string hMove;
	private string vMove;
	private string anchor;
	private string fire;

	private TankController tankC;
	private GunController gunC;

	void Start() {
		string prefix = "P" + playerM.playerNum;

		hMove = prefix + "Horizontal";
		vMove = prefix + "Vertical";
		anchor = prefix + "Anchor";
		fire = prefix + "Fire";

		tankC = playerM.tank.GetComponent<TankController>();
		gunC = playerM.tankGun.GetComponent<GunController>();
	}

	void Update() {
		// Anchor
		tankC.IsAnchored = (Input.GetAxisRaw(anchor) != 0);

		// Move
		Vector2 moveInput = Vector2.zero;
		moveInput.x = Input.GetAxis(hMove);
		moveInput.y = Input.GetAxis(vMove);
		if (moveInput != Vector2.zero) {
			tankC.MoveInput = moveInput;
		}

		// Fire
		if (Input.GetButtonDown(fire)) {
			gunC.Fire();
		}
	}
}
