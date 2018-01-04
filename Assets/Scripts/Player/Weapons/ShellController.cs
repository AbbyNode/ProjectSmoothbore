using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShellController : MonoBehaviour {
	public PlayerManager playerM;
	
	public float Damage { get; set; }

	public void Init(float damage, float speed, float destroyTime) {
		Damage = damage;

		GetComponent<Rigidbody2D>().velocity = this.transform.right * speed;
		Destroy(gameObject, destroyTime);
	}
}
