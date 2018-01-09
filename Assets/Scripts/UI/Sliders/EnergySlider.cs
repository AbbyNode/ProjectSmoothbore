using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlider : StatSlider {
	private void Start() {
		this.Init(PlayerEvents.EnergyChanged);
	}
}
