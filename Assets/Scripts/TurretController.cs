using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
	public GameObject tankShell;
	public Transform spawnPoint;
	public float fireDelta = 0.5f;
	public float shellSpeed = 5.0f;
	public float destroyTime = 2.0f;
    public int controllerNumber;

	private float nextFire = 0.5f;
	private GameObject newtankShell;
	private float myTime = 0.0f;

	void Update() {
		myTime = myTime + Time.deltaTime;

		if (Input.GetButton("P" + controllerNumber +"Fire") && myTime > nextFire) {
			nextFire = myTime + fireDelta;

			GameObject player = GlobalManager.FindParentPlayer(this.transform);
			newtankShell = Instantiate(tankShell, spawnPoint.position, this.transform.rotation, player.transform);

			newtankShell.GetComponent<Rigidbody2D>().velocity = this.transform.right * shellSpeed;

			nextFire = nextFire - myTime;
			myTime = 0.0F;
		}
	}
}
