using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : PlayerStat {
	private UnityEventFloat wasKilledEvent;
	private UnityEventFloat lostEvent;

	private Vector3 spawnPoint;
	private int lives;

	void Start() {
		EventManager eventM = playerM.eventManager;
		HealthTweaks healthTweaks = BalanceTweaks.GlobalInstance.health;

		Init(eventM.GetEvent(PlayerEvents.HealthChanged), healthTweaks.medHullHealth);
		SetStatValue(healthTweaks.medHullHealth);
		
		wasKilledEvent = eventM.GetEvent(PlayerEvents.WasKilled);
		lostEvent = eventM.GetEvent(PlayerEvents.Lost);

		spawnPoint = playerM.tankObj.transform.position;
		lives = healthTweaks.lives;
		eventM.GetEvent(PlayerEvents.WasHit).AddListener(WasHitEvent);
	}

	void WasHitEvent(float damage) {
		AdjustStatValue(-damage);
		if (GetStatValue() <= 0) { // Health 0
			lives -= 1; // Decrease lives
			wasKilledEvent.Invoke(lives);

			if (lives <= 0) { // No more lives
				DestroyObject(playerM.tankObj);
				lostEvent.Invoke(0);
			} else { // Respawn
				playerM.tankObj.transform.position = spawnPoint;
				SetStatPercent(100);
			}
		}
	}
}
