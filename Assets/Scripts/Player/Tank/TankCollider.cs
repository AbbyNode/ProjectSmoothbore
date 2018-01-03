using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollider : MonoBehaviour {
	public PlayerManager playerM;

	private UnityEventFloat wasHitEvent;
	private UnityEventFloat wasKilledEvent;

	private PlayerManager lastAttacker;

	private void Start() {
		EventManager eventM = playerM.eventManager;

		wasHitEvent = eventM.GetEvent(PlayerEvents.WasHit);

		eventM.GetEvent(PlayerEvents.WasKilled).AddListener((f) => {
			if (lastAttacker != null) {
				lastAttacker.eventManager.GetEvent(PlayerEvents.KilledEnemy).Invoke(playerM.playerNum);
			}
		});
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag(Tags.Shell)) {
			lastAttacker = collision.gameObject.GetComponent<ShellController>().playerM;
			lastAttacker.eventManager.GetEvent(PlayerEvents.HitEnemy).Invoke(playerM.playerNum);
			
			wasHitEvent.Invoke(collision.gameObject.GetComponent<ShellController>().damage);
		}
	}
}
