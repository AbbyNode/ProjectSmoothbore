using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleGenerator : MonoBehaviour {
	public PlayerManager playerM;

	private ModuleCostTweaks tweaks;

	private InventoryManager inventoryM;
	private Energy energy;

	void Start() {
		tweaks = tweaks = BalanceTweaks.GlobalInstance.moduleCosts;

		inventoryM = playerM.inventoryManager;
		energy = playerM.energy;
	}

	public void GenerateModule() {
		if (energy.GetStatValue() >= tweaks.rocketGun) {
			InventoryItem item = new InventoryItem();
			inventoryM.AddItem(item);
		} else if (energy.GetStatValue() >= tweaks.ricochetGun) {
			InventoryItem item = new InventoryItem();
			inventoryM.AddItem(item);
		} else if (energy.GetStatValue() >= tweaks.basicGun) {
			InventoryItem item = new InventoryItem();
			inventoryM.AddItem(item);
		} else {
			Debug.Log("Not enough energy");
		}
	}
}
