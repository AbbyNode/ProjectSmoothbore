using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
	public const int LAYER_START_INDEX = 12;

	public int playerNum;

	public EventManager eventManager;
	public InputManager inputManager;
	public UpgradeManager upgradeManager;

	public Health health;
	public Energy energy;

	public GameObject tankObj;
	public TankController tankController;

	public GameObject hullObj;

	public GameObject gunObj;
	public GunController gunController;

	public Camera cam;

	void Start() {
		int layer = LAYER_START_INDEX + playerNum;
		tankObj.layer = layer;
		hullObj.layer = layer;
		gunObj.layer = layer;
	}
}
