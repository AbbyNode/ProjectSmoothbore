using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryTweaks {
	public int inventorySize = 8;
}

[System.Serializable]
public class TankTweaks {
	public float maxSpeed = 10;  // Units per second
	public float rotationSpeed = 180; // Degrees per second
}

[System.Serializable]
public class HealthTweaks {
	public float player = 10;
}

[System.Serializable]
public class EnergyTweaks {
	public float maxEnergy = 100;

	public float move = 0.1f;
	public float breakCrate = 1;
	public float hitPlayer = 2;
	public float killPlayer = 10;
}

[System.Serializable]
public class ModuleCostTweaks {
	public float basicGun = 10;
	public float ricochetGun = 20;
	public float rocketGun = 30;
}

[System.Serializable]
public class DamageTweaks {
	public float basicShell = 1;
}

public class BalanceTweaks : MonoBehaviour {
	private static BalanceTweaks _globalInstance;

	public static BalanceTweaks GlobalInstance {
		get {
			if (_globalInstance == null) {
				Debug.LogError("No BalanceTweaks instance found");
			}
			return _globalInstance;
		}
	}

	public InventoryTweaks inventory;
	public TankTweaks tank;
	public HealthTweaks health;
	public EnergyTweaks energy;
	public ModuleCostTweaks moduleCosts;
	public DamageTweaks damage;

	private void Awake() {
		if (_globalInstance != null && _globalInstance != this) {
			Debug.LogError("Multiple BalanceTweaks instances found");
			Destroy(this.gameObject);
		} else {
			_globalInstance = this;
		}
	}
}

// https://gamedev.stackexchange.com/questions/116009/in-unity-how-do-i-correctly-implement-the-singleton-pattern/116010#116010
