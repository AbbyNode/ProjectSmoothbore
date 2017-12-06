using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public PlayerManager playerM;

	private Transform tankT;

	void Start() {
		tankT = playerM.tank.transform;

		this.GetComponent<Camera>().rect = new Rect((playerM.playerNum % 2 == 0 ? 0f : 0.5f), (playerM.playerNum <= 1 ? 0.5f : 0f), 0.5f, 0.5f);
	}

	private void Update() {
		if (tankT != null) {
			transform.position = new Vector3(tankT.position.x, tankT.position.y, transform.position.z);
		}
	}
}
