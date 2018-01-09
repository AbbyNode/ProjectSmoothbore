using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulseImgAlpha : MonoBehaviour {
	public float timeToFadeIn = 1;
	public float stayOnTime = 1;
	public float timeToFadeOut = 1;
	public float stayOffTime = 0;
	
	private Image img;

	private float timeAccumulator = 0;
	private float nextSwapTime = 0;

	private bool isOn = true;

	private Color destColor;
	private float colorChangeSpeed;

	void Start() {
		img = this.GetComponent<Image>();
	}

	void Update() {
		timeAccumulator = timeAccumulator + Time.deltaTime;

		if (timeAccumulator >= nextSwapTime) {
			if (isOn) {
				FadeToAlpha(0);
				colorChangeSpeed = timeToFadeOut;
				nextSwapTime = timeToFadeOut + stayOffTime;
				isOn = false;
			} else {
				FadeToAlpha(1);
				colorChangeSpeed = timeToFadeIn;
				nextSwapTime = timeToFadeIn + stayOnTime;
				isOn = true;
			}

			timeAccumulator = 0;
		}

		img.color = Color.Lerp(img.color, destColor, Time.deltaTime * colorChangeSpeed);
	}

	private void FadeToAlpha(float destAlpha) {
		destColor = img.color;
		destColor.a = destAlpha;
	}
}
