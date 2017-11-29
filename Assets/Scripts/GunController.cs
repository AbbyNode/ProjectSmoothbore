﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
	public PlayerManager playerM;

	public GameObject tankShell;
	public Transform spawnPoint;

	public float fireDelaySeconds = 0.5f;
	public float shellSpeed = 5.0f;
	public float destroyTime = 2.0f;

	private float nextFire = 0.5f;
	private float timeAccumulator = 0.0f;

	void Update() {
		timeAccumulator = timeAccumulator + Time.deltaTime;
	}

	public void Fire() {
		if (timeAccumulator > nextFire) {
			nextFire = timeAccumulator + fireDelaySeconds;

			GameObject shell = Instantiate(tankShell, spawnPoint.position, this.transform.rotation, playerM.gameObject.transform);

			shell.GetComponent<ShellController>().playerM = playerM;
			shell.GetComponent<Rigidbody2D>().velocity = this.transform.right * shellSpeed;

			nextFire = nextFire - timeAccumulator;
			timeAccumulator = 0.0F;
		}
	}
}