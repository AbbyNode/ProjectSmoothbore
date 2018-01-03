using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public int playerNum;

	public EventManager eventManager;
	public InputManager inputManager;
    
	public Health health;
	public Energy energy;

    public GameObject tankObj;
	public TankController tankController;

	public GameObject hullObj;

	public GameObject gunObj;
	public GunController gunController;

	public Camera cam;
}
