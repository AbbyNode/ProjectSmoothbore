using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSlider : StatSlider {
	private void Start() {
		this.Init(PlayerEvents.HealthChanged);
	}
}
