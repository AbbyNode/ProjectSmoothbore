using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShellController : MonoBehaviour {
	public float shellSpeed = 5.0f;

	private Rigidbody2D rbody;

	private EventManager em;
	private UnityEvent hitEvent;

	void Start() {
		// em = GlobalManager.GetPlayerEventManager(this.transform);

		// hitEvent = em.GetEvent("hitPlayer");

		rbody = this.GetComponent<Rigidbody2D>();
	}

	void Update() {
		rbody.velocity = this.transform.right * shellSpeed;
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		Destroy(this);
		// hitEvent.Invoke();
	}
}
