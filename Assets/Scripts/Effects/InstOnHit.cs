using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstOnHit : MonoBehaviour {
	public GameObject objToInst;

	void OnCollisionEnter2D(Collision2D coll) {
		GameObject obj = Instantiate(this.objToInst, this.transform.position, this.transform.rotation) as GameObject;
	}
}
