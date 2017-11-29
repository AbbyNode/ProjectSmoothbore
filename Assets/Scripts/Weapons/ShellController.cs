using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShellController : MonoBehaviour {
	public PlayerManager playerM;

	private GameObject thisPlayer;

	private EventManager eventM;
	private UnityEventFloat hitPlayerEvent;

	void Start() {
		thisPlayer = playerM.gameObject;

		eventM = playerM.eventManager;
		hitPlayerEvent = eventM.GetEvent("hitPlayer");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Destroy(this.gameObject);

		GameObject collPlayer = playerM.gameObject;
		//if (collPlayer != null && collPlayer != thisPlayer) {
		//	hitPlayerEvent.Invoke();
		//}       
		hitPlayerEvent.Invoke(0);
	}
}
