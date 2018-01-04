using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TankTweaks {
	public float maxSpeed = 10;  // Units per second
	public float rotationSpeed = 180; // Degrees per second
}

[System.Serializable]
public class HealthTweaks {
	public int lives = 3;
	public float health = 5;
}

[System.Serializable]
public class EnergyTweaks {
	public float maxEnergy = 100;

	public float move = 0f;
	public float breakCrate = 1;

	public float hitEnemyScale = 1;
	public float killEnemy = 10;
}

[System.Serializable]
public class ModuleCostTweaks {
	public float gunUpgrade = 50;
}

[System.Serializable]
public class WeaponTweaks {
	public float fireDelaySeconds = 0.5f;
	public int shellsPerShot = 1;
	public float shotSpread = 1;

	public float shellDamage = 1;
	public float shellSpeed = 20;
	public float shellDestroyTime = 2;

	public GameObject shellPrefab;
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

	public TankTweaks tank;
	public HealthTweaks health;
	public EnergyTweaks energy;
	public ModuleCostTweaks moduleCosts;
	public WeaponTweaks basicGun;
	public WeaponTweaks machineGun;
	public WeaponTweaks shotGun;
	public WeaponTweaks heavyGun;
	public WeaponTweaks sniperGun;

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
