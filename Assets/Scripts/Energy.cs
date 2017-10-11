using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
	public float maxEnergy = 100;
	public float currentEnergy;

	public Slider energybar;

	private EnergyTweaks tweaks;
	private EventManager em;

	private void Start() {
		em = this.GetComponent<EventManager>();

		currentEnergy = 0;

		energybar.value = calculateEnergy();

		em.GetEvent("move").AddListener(() => addEnergy(tweaks.move));
		em.GetEvent("breakCrate").AddListener(() => addEnergy(tweaks.breakCrate));
		em.GetEvent("hitPlayer").AddListener(() => addEnergy(tweaks.hitPlayer));
		em.GetEvent("killPlayer").AddListener(() => addEnergy(tweaks.killPlayer));
	}
	
	private float calculateEnergy() {
		return currentEnergy / maxEnergy;
	}
	
	public void addEnergy(float amt) {
		currentEnergy += amt;
		energybar.value = calculateEnergy();
	}
}
