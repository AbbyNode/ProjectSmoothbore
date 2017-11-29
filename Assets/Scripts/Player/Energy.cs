using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Energy : PlayerStat {
	private UnityEvent energyChangedEvent;

	private float maxEnergy;
	private float currentEnergy;

	private void Start() {
		EventManager eventM = playerM.eventManager;
		EnergyTweaks tweaks = BalanceTweaks.globalInstance.energy;

		maxEnergy = tweaks.maxEnergy;
		currentEnergy = 0;

		energyChangedEvent = eventM.GetEvent("energyChanged");

		eventM.GetEvent("move").AddListener(() => IncreaseEnergy(tweaks.move));
		eventM.GetEvent("breakCrate").AddListener(() => IncreaseEnergy(tweaks.breakCrate));
		eventM.GetEvent("hitPlayer").AddListener(() => IncreaseEnergy(tweaks.hitPlayer));
		eventM.GetEvent("killPlayer").AddListener(() => IncreaseEnergy(tweaks.killPlayer));
	}

	private void IncreaseEnergy(float amt) {
		currentEnergy += amt;
		energyChangedEvent.Invoke();
	}
}
