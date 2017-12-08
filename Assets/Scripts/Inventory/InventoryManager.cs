using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EquippedSlot {
	public const int Turret = 0;
	public const int Tracks = 1;
}

public class InventoryManager : MonoBehaviour {
	public const int EquipSlots = 2;

	public PlayerManager playerM;

	private InventoryItem[] inventory;
	private InventoryItem[] equipped;

	private UnityEventFloat gotItemEvent;
	private UnityEventFloat removedItemEvent;

	void Start() {
		EventManager eventM = playerM.eventManager;
		InventoryTweaks tweaks = BalanceTweaks.GlobalInstance.inventory;

		inventory = new InventoryItem[tweaks.inventorySize];
		equipped = new InventoryItem[EquipSlots];
	}

	void Update() {

	}

	/// <summary>
	/// Adds item to inventory if possible.
	/// </summary>
	/// <param name="item"></param>
	/// <returns>True if succeeded, false if inventory full</returns>
	public bool AddItem(InventoryItem item) {
		for (int i = 0; i < inventory.Length; i++) {
			if (inventory[i] == null) {
				inventory[i] = item;
				gotItemEvent.Invoke(i);
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// Removes item at index.
	/// </summary>
	/// <param name="index"></param>
	public void DeleteItem(int index) {
		removedItemEvent.Invoke(index);
		inventory[index] = null;
	}
}
