using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedback : MonoBehaviour {
	public GameObject explosionObj;
	public AudioClip explosionAudio;
	public float destroyTime = 1;

	void OnCollisionEnter2D(Collision2D coll) {
		GameObject sparkObj = Instantiate(explosionObj, this.transform.position, this.transform.rotation) as GameObject;
		Destroy(sparkObj, destroyTime);
	}
}
