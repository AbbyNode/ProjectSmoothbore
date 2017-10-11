using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
	public float maxEnergy = 100;
	public float currentEnergy;

	public Slider energybar;

	void Start() {
		currentEnergy = 0;

		energybar.value = calculateEnergy();
	}
	
	float calculateEnergy() {
		return currentEnergy / maxEnergy;
	}

	public void addEnergy(float amt) {
		currentEnergy += amt;
		energybar.value = calculateEnergy();
	}
}
