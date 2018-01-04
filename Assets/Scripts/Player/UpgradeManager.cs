using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {
	public const int TOTAL_TIERS = 3;

	public PlayerManager playerM;

	public int NextTier {
		get { return nextTier; }
		private set { nextTier = value; }
	}

	private ModuleCostTweaks moduleCosts;

	private int nextTier;

	private float upgradeThreshold;
	private bool upgradeAvailable;
	private UnityEventFloat upgradeTierAvailableEvent;
	private UnityEventFloat upgradeAppliedEvent;

	void Start() {
		moduleCosts = BalanceTweaks.GlobalInstance.moduleCosts;

		NextTier = 1;

		CheckNextThreshold();
		upgradeAvailable = false;
		upgradeTierAvailableEvent = playerM.eventManager.GetEvent(PlayerEvents.UpgradeAvailable);
		upgradeAppliedEvent = playerM.eventManager.GetEvent(PlayerEvents.UpgradeApplied);

		playerM.eventManager.GetEvent(PlayerEvents.EnergyChanged).AddListener(EnergyChangeEvent);
	}

	public void ChooseUpgrade(int option) {
		if (!upgradeAvailable) {
			return;
		}

		switch (NextTier) {
			default:
			case 1:
				Tier1(option);
				break;
			case 2:
				Tier2(option);
				break;
			case 3:
				Tier2(option);
				break;
		}

		upgradeAppliedEvent.Invoke(0);

		NextTier++;

		CheckNextThreshold();

		upgradeAvailable = false;
	}

	private void Tier1(int option) {
		switch (option) {
			case 1:
				playerM.gunController.WeaponTweaks = BalanceTweaks.GlobalInstance.shotGun;
				break;
			case 2:
				playerM.gunController.WeaponTweaks = BalanceTweaks.GlobalInstance.machineGun;
				break;
			case 3:
				playerM.gunController.WeaponTweaks = BalanceTweaks.GlobalInstance.heavyGun;
				break;
			default:
				break;
		}
		playerM.energy.AdjustStatValue(-BalanceTweaks.GlobalInstance.moduleCosts.gunUpgrade1);
	}

	/*
	private void Tier2(int option) {
		switch (option) {
			default:
			case 1:
				break;
			case 2:
				break;
			case 3:
				break;
		}
		playerM.energy.AdjustStatValue(-BalanceTweaks.GlobalInstance.moduleCosts.hullUpgrade1);
	}
	*/

	private void Tier2(int option) {
		switch (option) {
			default:
			case 1:
				playerM.gunController.WeaponTweaks = BalanceTweaks.GlobalInstance.sniperGun;
				break;
			case 2:
				playerM.gunController.WeaponTweaks = BalanceTweaks.GlobalInstance.flamethrowerGun;
				break;
			case 3:
				playerM.gunController.WeaponTweaks = BalanceTweaks.GlobalInstance.explosiveGun;
				break;
		}
		playerM.energy.AdjustStatValue(-BalanceTweaks.GlobalInstance.moduleCosts.gunUpgrade2);
	}

	public void CheckNextThreshold() {
		switch (NextTier) {
			default:
			case 1:
				upgradeThreshold = moduleCosts.gunUpgrade1;
				break;
			case 2:
				upgradeThreshold = moduleCosts.gunUpgrade2;
				break;
			/*
			case 3:
				upgradeThreshold = moduleCosts.gunUpgrade2;
				break;
			*/
		}
	}

	private void EnergyChangeEvent(float f) {
		if (!upgradeAvailable && playerM.energy.GetStatValue() >= upgradeThreshold) {
			upgradeTierAvailableEvent.Invoke(0);
			upgradeAvailable = true;
		}
	}
}
