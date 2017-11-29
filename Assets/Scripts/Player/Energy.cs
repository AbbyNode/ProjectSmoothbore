using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Energy : MonoBehaviour, PlayerStat {
	public PlayerManager playerM;

	private UnityEventFloat energyChangedEvent;

	private float maxEnergy;
	private float currentEnergy;

	private void Start() {
		EventManager eventM = playerM.eventManager;
		EnergyTweaks tweaks = BalanceTweaks.globalInstance.energy;

		maxEnergy = tweaks.maxEnergy;
		currentEnergy = 0;

		energyChangedEvent = eventM.GetEvent("energyChanged");

		eventM.GetEvent("move").AddListener((f) => IncreaseEnergy(tweaks.move));
		eventM.GetEvent("breakCrate").AddListener((f) => IncreaseEnergy(tweaks.breakCrate));
		eventM.GetEvent("hitPlayer").AddListener((f) => IncreaseEnergy(tweaks.hitPlayer));
		eventM.GetEvent("killPlayer").AddListener((f) => IncreaseEnergy(tweaks.killPlayer));
	}

	private void IncreaseEnergy(float amt) {
		currentEnergy += amt;
		energyChangedEvent.Invoke(currentEnergy);
	}

	public float getStatValue() {
		return currentEnergy;
	}

	public float getStatPercent() {
		return currentEnergy / maxEnergy * 100;
	}
}
