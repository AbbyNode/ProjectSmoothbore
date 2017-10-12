using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlider : MonoBehaviour {
	private Slider slider;
	private Energy tankEnergy;

	void Start() {
		EventManager em = GlobalManager.GetPlayerEventManager(this.transform);
		em.GetEvent("energyChanged").AddListener(energyChanged);

		tankEnergy = GlobalManager.GetPlayerEnergy(this.transform);

		slider = this.GetComponent<Slider>();
	}

	private void energyChanged() {
		slider.value = tankEnergy.getEnergyPercent();
	}
}
