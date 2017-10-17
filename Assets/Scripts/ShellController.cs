using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShellController : MonoBehaviour {
	private GameObject thisPlayer;
	private EventManager em;
	private UnityEvent hitPlayerEvent;

	void Start() {
		thisPlayer = GlobalManager.FindParentPlayer(this.transform);
		em = thisPlayer.GetComponent<EventManager>();
		hitPlayerEvent = em.GetEvent("hitPlayer");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Destroy(this.gameObject);

		GameObject collPlayer = GlobalManager.FindParentPlayer(coll.transform);
		if (collPlayer != null && collPlayer != thisPlayer) {
			hitPlayerEvent.Invoke();
		}
	}
}
