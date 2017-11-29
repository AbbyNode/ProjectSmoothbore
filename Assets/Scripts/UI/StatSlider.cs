using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class StatSlider : MonoBehaviour {
	public PlayerManager playerM;

	protected PlayerStat stat;

	private Slider slider;

	void Start() {
		EventManager eventM = playerM.eventManager;
		// eventM.GetEvent().AddListener(statChanged);

		slider = this.GetComponent<Slider>();
	}

	private void statChanged() {
		if (stat != null) {
			slider.value = stat.getStatPercent();
		}
	}
}
