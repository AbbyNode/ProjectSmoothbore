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

	private UnityEventFloat hitOtherPlayerEvent;

	void Start() {
		hitOtherPlayerEvent = playerM.eventManager.GetEvent(PlayerEvents.HitOtherPlayer);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Destroy(this.gameObject);
		hitOtherPlayerEvent.Invoke(0);
	}
}
