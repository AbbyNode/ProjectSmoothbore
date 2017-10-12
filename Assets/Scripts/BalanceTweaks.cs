using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class BalanceTweaks : MonoBehaviour {
	private static BalanceTweaks _globalInstance;

	public static BalanceTweaks globalInstance {
		get {
			if (_globalInstance == null) {
				Debug.LogError("No BalanceTweaks instance found");
			}
			return _globalInstance;
		}
	}

	public HealthTweaks health;
	public EnergyTweaks energy;

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
