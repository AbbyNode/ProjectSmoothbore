using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class EquippedSlot {
	public const int Turret = 0;
	public const int Tracks = 1;
}

public class InventoryManager : MonoBehaviour {
	public const int EquipSlots = 2;

	public PlayerManager playerM;

	public InventoryItem startingGun;

	private InventoryItem[] inventory;
	private InventoryItem[] equipped;

	private GameObject inventoryUI;
	private GameObject equipUI;

	private UnityEventFloat gotItemEvent;
	private UnityEventFloat removedItemEvent;

	private GameObject tank;
	private GameObject tankGun;

	private GunController gunC;

	void Start() {
		EventManager eventM = playerM.eventManager;
		InventoryTweaks tweaks = BalanceTweaks.GlobalInstance.inventory;

		inventory = new InventoryItem[tweaks.inventorySize];
		equipped = new InventoryItem[EquipSlots];

		// inventoryUI = playerM.inventorySlots;
		// equipUI = playerM.equipSlots;

		gotItemEvent = eventM.GetEvent(PlayerEvents.GotItem);
		removedItemEvent = eventM.GetEvent(PlayerEvents.RemovedItem);

		tank = playerM.tank;
		tankGun = playerM.tankGun;

		gunC = playerM.gunController;

		AddItem(startingGun);
		equipItem(0, 0);
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
				SetInventoryIcon(i, item.inventoryIcon);
				gotItemEvent.Invoke(i);
				return true;
			}
		}
		return false;
	}

	public void equipItem(int inventoryIndex, int equippedIndex) {
		if (inventory[inventoryIndex] != null) {
			equipped[equippedIndex] = inventory[inventoryIndex];

			Destroy(tankGun);
			tankGun = Instantiate(equipped[equippedIndex].inGameObject, tank.transform);

            playerM.tankGun = tankGun;
            playerM.gunController = tankGun.GetComponent<GunController>();

            // TODO: Organize
            gunC = playerM.gunController;
            gunC.playerM = playerM;

            SetInventoryIcon(inventoryIndex, null);
			SetEquipIcon(equippedIndex, equipped[equippedIndex].inventoryIcon);

			inventory[inventoryIndex] = null;
		}
	}

	private void SetInventoryIcon(int index, Sprite icon) {
		Transform obj = inventoryUI.transform.GetChild(index).GetChild(0);
		obj.GetComponent<Image>().sprite = icon;
	}

	private void SetEquipIcon(int index, Sprite icon) {
		Transform obj = equipUI.transform.GetChild(index).GetChild(0);
		obj.GetComponent<Image>().sprite = icon;
	}

	/// <summary>
	/// Removes item at index.
	/// </summary>
	/// <param name="index"></param>
	public void DeleteItem(int index) {
		inventory[index] = null;
		removedItemEvent.Invoke(index);
	}
}
