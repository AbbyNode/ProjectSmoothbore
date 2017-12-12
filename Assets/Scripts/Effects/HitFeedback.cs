using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedback : MonoBehaviour {
	public GameObject SparkObj;
	public float destroyTime = 1;

	void OnCollisionEnter2D(Collision2D coll) {
		GameObject sparkObj = Instantiate(SparkObj, this.transform.position, this.transform.rotation) as GameObject;
		Destroy(sparkObj, destroyTime);
	}
}
