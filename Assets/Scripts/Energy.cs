using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
	public PlayerManager playerM;

	private UnityEvent energyChangedEvent;

	private float maxEnergy;
	private float currentEnergy;

	public float EnergyValue {
		get {
			return currentEnergy;
		}
	}

	public float EnergyPercent {
		get {
			return currentEnergy / maxEnergy * 100;
		}
	}

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
