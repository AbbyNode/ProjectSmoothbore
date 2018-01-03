using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour {
	public string hitTag;

	private void OnCollisionEnter2D(Collision2D collision) {
		if (hitTag == "" || collision.gameObject.CompareTag(hitTag)) {
			Destroy(this.gameObject);
		}
	}
}