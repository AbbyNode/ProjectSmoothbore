using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class tankShellController : MonoBehaviour {
	public float shellSpeed = 5.0f;

	private Rigidbody2D rbody;

	private EventManager em;
	private UnityEvent dmg_playerEvent;
	// Use this for initialization
	void Start() {
		rbody = this.GetComponent<Rigidbody2D>();


	}

	// Update is called once per frame
	void Update() {
		rbody.velocity = this.transform.right * shellSpeed;
	}
}
