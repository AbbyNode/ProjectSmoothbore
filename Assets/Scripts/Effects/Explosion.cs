using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
	public AudioClip explosionAudio;
	public float destroyTime = 1;

	void Start() {
		Destroy(this.gameObject, destroyTime);
	}

	private void Awake() {
		this.GetComponent<AudioSource>().PlayOneShot(explosionAudio, 1);
	}
}
