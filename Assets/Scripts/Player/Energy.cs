using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : PlayerStat {
	private void Start() {
		EventManager eventM = playerM.eventManager;
		EnergyTweaks tweaks = BalanceTweaks.GlobalInstance.energy;

		Init(eventM.GetEvent(PlayerEvents.EnergyChanged), tweaks.maxEnergy);

		eventM.GetEvent(PlayerEvents.Move).AddListener((f) => AdjustStatValue(tweaks.move));
		eventM.GetEvent(PlayerEvents.BreakCrate).AddListener((f) => AdjustStatValue(tweaks.breakCrate));
		eventM.GetEvent(PlayerEvents.HitEnemy).AddListener((f) => AdjustStatValue(tweaks.hitPlayer));
		eventM.GetEvent(PlayerEvents.KilledEnemy).AddListener((f) => AdjustStatValue(tweaks.killPlayer));
	}
}
