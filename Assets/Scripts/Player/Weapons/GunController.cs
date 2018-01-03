using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	public const int LAYER_START_INDEX = 8;

	public PlayerManager playerM;

	public Transform shellSpawn;

	public GameObject shellPrefab;

	public float fireDelaySeconds = 0.5f;
	public int shellsPerShot = 1;
	public float shellSpreadDeg = 1;

	private float nextFire = 0.5f;
	private float timeAccumulator = 0.0f;

	void Update() {
		timeAccumulator = timeAccumulator + Time.deltaTime;
	}

	public void Fire() {
		if (timeAccumulator > fireDelaySeconds) {
			float anglePerShell = shellSpreadDeg / shellsPerShot;
			float startAngle = this.transform.rotation.eulerAngles.z - (shellSpreadDeg/2);
			float endAngle = startAngle + shellSpreadDeg;

			for (int i = 0; i < shellsPerShot; i++) {
				float shellAngle = Random.Range(startAngle, endAngle);
				
				GameObject shellInst = Instantiate(shellPrefab, shellSpawn.position, Quaternion.Euler(0, 0, shellAngle), playerM.gameObject.transform);

				ShellController shellC = shellInst.GetComponent<ShellController>();
				shellC.playerM = playerM;

				shellInst.layer = LAYER_START_INDEX + playerM.playerNum;
			}

			timeAccumulator = 0.0F;
		}
	}
}
