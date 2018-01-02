using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShellController : MonoBehaviour {
	public PlayerManager playerM;

	public float Damage {
		get {
			return BalanceTweaks.GlobalInstance.damage.basicShell;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Destroy(this.gameObject);
	}
}
