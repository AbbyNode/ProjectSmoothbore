using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	public PlayerManager playerM;

	private Energy energy;

	private InventoryItem[] items;
	private int selectedIndex;

	void Start() {
		energy = playerM.energy;

		items = new InventoryItem[8];
	}

	void Update() {

	}

	public void OpenInventory() {
		selectedIndex = 0;
	}

	public void GenerateItem() {
		InventoryItem item = null;

		if (energy.getStatValue() >= 50) {
			Debug.Log("Has 50");
		} else if (energy.getStatValue() >= 100) {
			Debug.Log("Has 100");
		}

		for (int i = 0; i < items.Length; i++) {
			if (items[i] == null) {
				items[i] = item;
				return;
			}
		}

		Debug.Log("Inventory full");
	}

	public void DestroySelectedItem() {
		if (items[selectedIndex] != null) {
			Destroy(items[selectedIndex]);
			items[selectedIndex] = null;
		}
	}
}
