using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour {
	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag(Tags.Shell)) {
			Destroy(this.gameObject);
		}
	}
}