using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : PlayerStat {
	void Start() {
		EventManager eventM = playerM.eventManager;
		HealthTweaks tweaks = BalanceTweaks.globalInstance.health;

		this.Init(eventM.GetEvent(PlayerEvents.HealthChanged), tweaks.player);
	}
}
