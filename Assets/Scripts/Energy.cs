using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
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
		EventManager em = GlobalManager.FindPlayerEventManager(this.transform);
		EnergyTweaks tweaks = BalanceTweaks.globalInstance.energy;

		maxEnergy = tweaks.maxEnergy;
		currentEnergy = 0;

		energyChangedEvent = em.GetEvent("energyChanged");

		em.GetEvent("move").AddListener(() => IncreaseEnergy(tweaks.move));
		em.GetEvent("breakCrate").AddListener(() => IncreaseEnergy(tweaks.breakCrate));
		em.GetEvent("hitPlayer").AddListener(() => IncreaseEnergy(tweaks.hitPlayer));
		em.GetEvent("killPlayer").AddListener(() => IncreaseEnergy(tweaks.killPlayer));
	}

	private void IncreaseEnergy(float amt) {
		currentEnergy += amt;
		energyChangedEvent.Invoke();
	}
}
