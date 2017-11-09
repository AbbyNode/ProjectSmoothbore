using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	private InventoryItem[] items;
	private int selectedIndex;

	void Start() {
		items = new InventoryItem[8];
	}

	void Update() {

	}

	public void OpenInventory() {
		selectedIndex = 0;
	}

	public void GenerateItem(InventoryItem item) {
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
