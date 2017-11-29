using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlider : MonoBehaviour {
	public PlayerManager playerM;

	private Slider slider;
	private Energy tankEnergy;

	void Start() {
		EventManager eventM = playerM.eventManager;
		eventM.GetEvent("energyChanged").AddListener(energyChanged);

		tankEnergy = playerM.energy;

		slider = this.GetComponent<Slider>();
	}

	private void energyChanged(float newEnergy) {
		slider.value = newEnergy;
	}
}
