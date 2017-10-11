using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
	EventManager em;

	public float maxEnergy = 100;
	public float currentEnergy;

	public Slider energybar;

	private void Start() {
		currentEnergy = 0;

		energybar.value = calculateEnergy();

		em.GetEvent("move").AddListener(() => addEnergy(1));
	}
	
	private float calculateEnergy() {
		return currentEnergy / maxEnergy;
	}
	
	public void addEnergy(float amt) {
		currentEnergy += amt;
		energybar.value = calculateEnergy();
	}
}
