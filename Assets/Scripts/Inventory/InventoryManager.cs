using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
	public PlayerManager playerM;

	private InventoryItem[] inventory;
	private InventoryItem[] equipped;

	void Start() {
		EventManager eventM = playerM.eventManager;
		InventoryTweaks tweaks = BalanceTweaks.GlobalInstance.inventory;
	}

	void Update() {

	}
}
