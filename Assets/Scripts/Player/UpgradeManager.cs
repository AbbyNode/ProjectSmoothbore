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
				Tier3(option);
				break;
		}

		upgradeAppliedEvent.Invoke(0);

		NextTier++;

		CheckNextThreshold();

		upgradeAvailable = false;
	}

	private void Tier1(int option) {
		switch (option) {
			default:
			case 1:
				ChangeGun(BalanceTweaks.GlobalInstance.weaponPrefabs.shotGun, BalanceTweaks.GlobalInstance.shotGun);
				break;
			case 2:
				ChangeGun(BalanceTweaks.GlobalInstance.weaponPrefabs.machineGun, BalanceTweaks.GlobalInstance.machineGun);
				break;
			case 3:
				ChangeGun(BalanceTweaks.GlobalInstance.weaponPrefabs.heavyGun, BalanceTweaks.GlobalInstance.heavyGun);
				break;
		}

		playerM.energy.AdjustStatValue(-BalanceTweaks.GlobalInstance.moduleCosts.gunUpgrade1);
	}

	private void Tier2(int option) {
		switch (option) {
			default:
			case 1:
				ChangeGun(BalanceTweaks.GlobalInstance.weaponPrefabs.sniperGun, BalanceTweaks.GlobalInstance.sniperGun);
				break;
			case 2:
				ChangeGun(BalanceTweaks.GlobalInstance.weaponPrefabs.flamethrowerGun, BalanceTweaks.GlobalInstance.flamethrowerGun);
				break;
			case 3:
				ChangeGun(BalanceTweaks.GlobalInstance.weaponPrefabs.explosiveGun, BalanceTweaks.GlobalInstance.explosiveGun);
				break;
		}

		playerM.energy.AdjustStatValue(-BalanceTweaks.GlobalInstance.moduleCosts.gunUpgrade2);
	}

	private void Tier3(int option) {
		switch (option) {
			default:
			case 1:
				ChangeHull(BalanceTweaks.GlobalInstance.hullPrefabs.heavyHull, BalanceTweaks.GlobalInstance.health.heavyHullHealth, BalanceTweaks.GlobalInstance.heavyTank);
				break;
			case 2:
				break;
			case 3:
				ChangeHull(BalanceTweaks.GlobalInstance.hullPrefabs.lightHull, BalanceTweaks.GlobalInstance.health.lightHullHealth, BalanceTweaks.GlobalInstance.lightTank);
				break;
		}
		playerM.energy.AdjustStatValue(-BalanceTweaks.GlobalInstance.moduleCosts.hullUpgrade1);
	}

	private void ChangeGun(GameObject prefab, WeaponTweaks tweaks) {
		GameObject oldGun = playerM.gunObj;
		GameObject newGun = Instantiate(prefab, oldGun.transform.position, oldGun.transform.rotation, playerM.tankObj.transform);
		Destroy(oldGun);

		playerM.gunObj = newGun;
		playerM.gunObj.layer = PlayerManager.LAYER_START_INDEX + playerM.playerNum;

		playerM.gunController = playerM.gunObj.GetComponent<GunController>();
		playerM.gunController.playerM = playerM;

		playerM.gunController.WeaponTweaks = tweaks;
	}

	private void ChangeHull(GameObject prefab, float health, TankTweaks tankTweaks) {
		float healthPercent = playerM.health.GetStatPercent();

		GameObject oldHull = playerM.hullObj;
		GameObject newHull = Instantiate(prefab, oldHull.transform.position, oldHull.transform.rotation, playerM.tankObj.transform);
		Destroy(oldHull);

		playerM.hullObj = newHull;
		playerM.hullObj.layer = PlayerManager.LAYER_START_INDEX + playerM.playerNum;

		playerM.health.SetMaxValue(health);
		playerM.health.SetStatPercent(healthPercent);

		playerM.tankController.TankTweaksProp = tankTweaks;
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
			case 3:
				upgradeThreshold = moduleCosts.hullUpgrade1;
				break;
		}
	}


	private void EnergyChangeEvent(float f) {
		if (!upgradeAvailable && NextTier <= TOTAL_TIERS && playerM.energy.GetStatValue() >= upgradeThreshold) {
			upgradeTierAvailableEvent.Invoke(0);
			upgradeAvailable = true;
		}
	}
}
