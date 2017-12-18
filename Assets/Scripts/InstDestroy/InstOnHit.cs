using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstOnHit : MonoBehaviour {
	public string hitTag;
	public GameObject objToInst;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.CompareTag(hitTag)) {
			GameObject obj = Instantiate(this.objToInst, this.transform.position, this.transform.rotation) as GameObject;
		}
	}
}
