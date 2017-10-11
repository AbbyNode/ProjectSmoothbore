using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
	public float maxEnergy = 100;
	public float currentEnergy;

	public Slider energybar;

	private EventManager em;

	private void Start() {
		em = this.GetComponent<EventManager>();

		currentEnergy = 0;

		energybar.value = calculateEnergy();

		em.GetEvent("move").AddListener(() => addEnergy(1));
		em.GetEvent("break_crate").AddListener(() => addEnergy(1));
		em.GetEvent("dmg_player").AddListener(() => addEnergy(1));
		em.GetEvent("kill_player").AddListener(() => addEnergy(1));
	}
	
	private float calculateEnergy() {
		return currentEnergy / maxEnergy;
	}
	
	public void addEnergy(float amt) {
		currentEnergy += amt;
		energybar.value = calculateEnergy();
	}
}
