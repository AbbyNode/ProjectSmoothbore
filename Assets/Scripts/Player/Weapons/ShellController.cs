using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShellController : MonoBehaviour {
	public PlayerManager playerM;

	public float damage = 1;

	public void Init(float damage, float speed, float destroyTime) {
		this.damage = damage;

		GetComponent<Rigidbody2D>().velocity = this.transform.right * speed;
		Destroy(gameObject, destroyTime);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Destroy(this.gameObject);
	}
}
