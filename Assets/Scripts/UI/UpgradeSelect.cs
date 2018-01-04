﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelect : MonoBehaviour {
	public PlayerManager playerM;

	void Start() {
		EventManager eventM = playerM.eventManager;
		eventM.GetEvent(PlayerEvents.EnergyChanged).AddListener((f) => {
			if (playerM.energy.GetStatValue() >= BalanceTweaks.GlobalInstance.moduleCosts.gunUpgrade) {
				this.GetComponent<CanvasGroup>().alpha = 1;
			}
		});
	}
}
