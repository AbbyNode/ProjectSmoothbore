using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : PlayerStat {
	void Start() {
		EventManager eventM = playerM.eventManager;
		HealthTweaks tweaks = BalanceTweaks.GlobalInstance.health;
		
		Init(eventM.GetEvent(PlayerEvents.HealthChanged), tweaks.player);
		SetStatValue(tweaks.player);

		UnityEventFloat wasKilledEvent = eventM.GetEvent(PlayerEvents.WasKilled);

		eventM.GetEvent(PlayerEvents.WasHit).AddListener((damage) => {
			AdjustStatValue(-damage);
			if (GetStatValue() <= 0) {
				Destroy(this.gameObject);
				wasKilledEvent.Invoke(0);
			}
		});
	}
}
