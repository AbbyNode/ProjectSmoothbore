using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollider : MonoBehaviour {
	public PlayerManager playerM;

	private UnityEventFloat wasHitEvent;

	private void Start() {
		EventManager eventM = playerM.eventManager;

		wasHitEvent = eventM.GetEvent(PlayerEvents.WasHit);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Shell")) {
			wasHitEvent.Invoke(collision.gameObject.GetComponent<ShellController>().Damage);
		}
	}
}
