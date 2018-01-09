using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class StatSlider : MonoBehaviour {
	public PlayerManager playerM;

	private Slider slider;

	protected void Init(string changedEvent) {
		slider = this.GetComponent<Slider>();
		playerM.eventManager.GetEvent(changedEvent).AddListener(AdjustSlider);
	}

	private void AdjustSlider(float newStatPercent) {
		slider.value = newStatPercent;
	}
}
