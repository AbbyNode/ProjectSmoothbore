using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelect : MonoBehaviour {
	public PlayerManager playerM;

	public CanvasGroup canvasGroupTier1;
	public CanvasGroup canvasGroupTier2;
	public CanvasGroup canvasGroupTier3;

	void Start() {
		EventManager eventM = playerM.eventManager;
		eventM.GetEvent(PlayerEvents.UpgradeAvailable).AddListener(UpgradeAvailable);
		eventM.GetEvent(PlayerEvents.UpgradeApplied).AddListener(UpgradeApplied);
	}

	void UpgradeAvailable(float f) {
		switch (playerM.upgradeManager.NextTier) {
			case 1:
				canvasGroupTier1.alpha = 1;
				break;
			case 2:
				canvasGroupTier2.alpha = 1;
				break;
			case 3:
				canvasGroupTier3.alpha = 1;
				break;
		}
	}

	void UpgradeApplied(float f) {
		canvasGroupTier1.alpha = 0;
		canvasGroupTier2.alpha = 0;
		canvasGroupTier3.alpha = 0;
	}
}
