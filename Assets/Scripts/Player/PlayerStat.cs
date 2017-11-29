using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStat : MonoBehaviour {
	public PlayerManager playerM;
	public string changedEvent;

	protected float maxStatValue;
	protected float currentStatValue;

	public float getStatValue() {
		return this.currentStatValue;
	}

	public float getStatPercent() {
		return this.currentStatValue / this.maxStatValue * 100;
	}
}
