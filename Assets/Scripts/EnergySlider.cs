using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlider : MonoBehaviour {
	private Slider slider;
	private Energy tankEnergy;

	void Start() {
		GameObject player = GlobalManager.FindParentPlayer(this.transform);

		EventManager em = player.GetComponent<EventManager>();
		em.GetEvent("energyChanged").AddListener(energyChanged);

		tankEnergy = player.GetComponent<Energy>();

		slider = this.GetComponent<Slider>();
	}

	private void energyChanged() {
		slider.value = tankEnergy.getEnergyPercent();
	}
}
