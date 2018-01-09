using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseCanvasAlpha : MonoBehaviour {
	public float timeToFadeIn = 1;
	public float stayOnTime = 1;
	public float timeToFadeOut = 1;
	public float stayOffTime = 0;

	private CanvasGroup canvas;

	private float timeAccumulator = 0;
	private float nextSwapTime = 0;

	private bool isOn = true;

	private float destAlpha;
	private float alphaChangeSpeed;

	void Start() {
		canvas = this.GetComponent<CanvasGroup>();
	}

	void Update() {
		timeAccumulator = timeAccumulator + Time.deltaTime;

		if (timeAccumulator >= nextSwapTime) {
			if (isOn) {
				destAlpha = 0;
				alphaChangeSpeed = timeToFadeOut;
				nextSwapTime = timeToFadeOut + stayOffTime;
				isOn = false;
			} else {
				destAlpha = 1;
				alphaChangeSpeed = timeToFadeIn;
				nextSwapTime = timeToFadeIn + stayOnTime;
				isOn = true;
			}

			timeAccumulator = 0;
		}

		canvas.alpha = Mathf.Lerp(canvas.alpha, destAlpha, Time.deltaTime * alphaChangeSpeed);
	}
}
