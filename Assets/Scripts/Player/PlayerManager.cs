using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public int playerNum;

	public EventManager eventManager;
	public InputManager inputManager;

	public InventoryManager inventoryManager;
	public ModuleGenerator moduleGenerator;

	public Health health;
	public Energy energy;

    public GameObject inventorySlots;
    public GameObject equipSlots;

    public GameObject tank;
	public TankController tankController;

	public GameObject tankGun;
	public GunController gunController;

	public Camera cam;
}
