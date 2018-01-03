using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : PlayerStat {
    public int lives = 3;
    void Start() {
		EventManager eventM = playerM.eventManager;
		HealthTweaks tweaks = BalanceTweaks.GlobalInstance.health;
        Vector3 spawnPoint = playerM.tankObj.transform.position;
		
		Init(eventM.GetEvent(PlayerEvents.HealthChanged), tweaks.player);
		SetStatValue(tweaks.player);

		UnityEventFloat wasKilledEvent = eventM.GetEvent(PlayerEvents.WasKilled);
        UnityEventFloat lostEvent = eventM.GetEvent(PlayerEvents.Lost);

		eventM.GetEvent(PlayerEvents.WasHit).AddListener((damage) => {
			AdjustStatValue(-damage);
			if (GetStatValue() <= 0) {
                playerM.tankObj.transform.position = spawnPoint;
                SetStatValue(100);
                lives -= 1;

				wasKilledEvent.Invoke(lives);
			}
            if (lives <= 0)
            {
                DestroyObject(playerM.tankObj);
                lostEvent.Invoke(0);
            }
		});
	}
}
