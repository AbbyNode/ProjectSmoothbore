using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShellController : MonoBehaviour {
	public PlayerManager playerM;

	public float damage;
	public float speed;
	public float destroyTime;

	void Start() {
		GetComponent<Rigidbody2D>().velocity = this.transform.right * speed;
		Destroy(gameObject, destroyTime);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Destroy(this.gameObject);
	}
}
