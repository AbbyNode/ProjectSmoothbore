﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShellController : MonoBehaviour {
	public PlayerManager playerM;

	public float Damage {
		get {
			return BalanceTweaks.GlobalInstance.damage.basicShell;
		}
	}

	private UnityEventFloat hitEnemyEvent;

	public void Init() {
		hitEnemyEvent = playerM.eventManager.GetEvent(PlayerEvents.HitEnemy);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (hitEnemyEvent == null) {
			Debug.LogError("Event not set " + PlayerEvents.HitEnemy);
			return;
		}

		hitEnemyEvent.Invoke(Damage);
		Destroy(this.gameObject);
	}
}