using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatSlider : MonoBehaviour {
	public PlayerManager playerM;

	public string triggerEvent;

	private Slider slider;
	private Energy tankEnergy;

	void Start() {
		EventManager eventM = playerM.eventManager;
		eventM.GetEvent(triggerEvent).AddListener(statChanged);

		tankEnergy = playerM.energy;

		slider = this.GetComponent<Slider>();
	}

	private void statChanged() {

	}

	private void energyChanged() {
		slider.value = tankEnergy.getStatPercent();
	}
}
