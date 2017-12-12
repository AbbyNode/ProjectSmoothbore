using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollider : MonoBehaviour {
	public PlayerManager playerM;

	private UnityEventFloat wasHitEvent;
	private UnityEventFloat wasKilledEvent;

	private GameObject lastCollidedShell;

	private void Start() {
		EventManager eventM = playerM.eventManager;

		wasHitEvent = eventM.GetEvent(PlayerEvents.WasHit);
		eventM.GetEvent(PlayerEvents.WasKilled).AddListener((f) => {
			if (lastCollidedShell != null) {
				lastCollidedShell.GetComponent<ShellController>().playerM
					.eventManager.GetEvent(PlayerEvents.KilledEnemy)
					.Invoke(playerM.playerNum);
			}
		});
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag(Tags.Shell)) {
			lastCollidedShell = collision.gameObject;
			wasHitEvent.Invoke(collision.gameObject.GetComponent<ShellController>().Damage);
		}
	}
}
