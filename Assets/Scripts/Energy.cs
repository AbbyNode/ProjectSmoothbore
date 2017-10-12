using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
	private UnityEvent energyChangedEvent;

	private float maxEnergy;
	private float currentEnergy;

	private void Start() {
		EventManager em = GlobalManager.GetPlayerEventManager(this.transform);
		EnergyTweaks tweaks = BalanceTweaks.globalInstance.energy;

		maxEnergy = tweaks.maxEnergy;
		currentEnergy = 0;

		energyChangedEvent = em.GetEvent("energyChanged");

		em.GetEvent("move").AddListener(() => increaseEnergy(tweaks.move));
		em.GetEvent("breakCrate").AddListener(() => increaseEnergy(tweaks.breakCrate));
		em.GetEvent("hitPlayer").AddListener(() => increaseEnergy(tweaks.hitPlayer));
		em.GetEvent("killPlayer").AddListener(() => increaseEnergy(tweaks.killPlayer));
	}

	public float getEnergyPercent() {
		return currentEnergy / maxEnergy;
	}

	private void increaseEnergy(float amt) {
		currentEnergy += amt;
		energyChangedEvent.Invoke();
	}
}
