using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
	public float maxEnergy = 100;
	public float currentEnergy;

	private EnergyTweaks tweaks;
	private EventManager em;
    private UnityEvent increaseEnergyEvent;

	private void Start() {
		em = this.GetComponent<EventManager>();

		currentEnergy = 0;

        increaseEnergyEvent = em.GetEvent("increaseEnergy");

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
        increaseEnergyEvent.Invoke();
	}
}
