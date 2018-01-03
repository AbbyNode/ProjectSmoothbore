using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public int playerNum;

	public EventManager eventManager;
	public InputManager inputManager;
    
	public Health health;
	public Energy energy;

    public GameObject tank;
	public TankController tankController;

	public GameObject tankGun;
	public GunController gunController;

	public Camera cam;
}
