using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	public const int LAYER_START_INDEX = 8;

	public PlayerManager playerM;

	public Transform shellSpawn;

	public GameObject defaultShell;

	/*
	public GameObject shellPrefab;

	public float fireDelaySeconds = 0.5f;
	public int shellsPerShot = 1;
	public float shellSpreadDeg = 1;
	*/

	public WeaponTweaks WeaponTweaks {
		get {
			return weaponTweaks;
		}
		set {
			weaponTweaks = value;
			if (weaponTweaks.shellPrefab == null) {
				weaponTweaks.shellPrefab = defaultShell;
			}
		}
	}

	private WeaponTweaks weaponTweaks;

	private float nextFire = 0.5f;
	private float timeAccumulator = 0.0f;

	void Start() {
		WeaponTweaks = BalanceTweaks.GlobalInstance.basicGun;
	}

	void Update() {
		timeAccumulator = timeAccumulator + Time.deltaTime;
	}

	public void Fire() {
		if (timeAccumulator > weaponTweaks.fireDelaySeconds) {
			float anglePerShell = weaponTweaks.shotSpread / weaponTweaks.shellsPerShot;
			float startAngle = this.transform.rotation.eulerAngles.z - (weaponTweaks.shotSpread / 2);
			float endAngle = startAngle + weaponTweaks.shotSpread;

			for (int i = 0; i < weaponTweaks.shellsPerShot; i++) {
				float shellAngle = Random.Range(startAngle, endAngle);

				GameObject shellInst = Instantiate(weaponTweaks.shellPrefab, shellSpawn.position, Quaternion.Euler(0, 0, shellAngle), playerM.gameObject.transform);

				shellInst.layer = LAYER_START_INDEX + playerM.playerNum;

				ShellController shellC = shellInst.GetComponent<ShellController>();
				shellC.playerM = playerM;

				shellC.Init(weaponTweaks.shellDamage, weaponTweaks.shellSpeed, weaponTweaks.shellDestroyTime);
			}

			timeAccumulator = 0.0F;
		}
	}
}
