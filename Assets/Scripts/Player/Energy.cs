using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : PlayerStat {
	private void Start() {
		EventManager eventM = playerM.eventManager;
		EnergyTweaks tweaks = BalanceTweaks.GlobalInstance.energy;

		this.Init(eventM.GetEvent(PlayerEvents.EnergyChanged), tweaks.maxEnergy);

		eventM.GetEvent("move").AddListener((f) => AdjustStatValue(tweaks.move));
		eventM.GetEvent("breakCrate").AddListener((f) => AdjustStatValue(tweaks.breakCrate));
		eventM.GetEvent("hitPlayer").AddListener((f) => AdjustStatValue(tweaks.hitPlayer));
		eventM.GetEvent("killPlayer").AddListener((f) => AdjustStatValue(tweaks.killPlayer));
	}
}
