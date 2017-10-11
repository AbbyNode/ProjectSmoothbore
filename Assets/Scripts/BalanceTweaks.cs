using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnergyTweaks {
	public float move = 0.1f;
	public float breakCrate = 1;
	public float hitPlayer = 2;
	public float killPlayer = 10;
}

public class BalanceTweaks : MonoBehaviour {
	public EnergyTweaks energyIncrements;
}
