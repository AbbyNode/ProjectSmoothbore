using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	public static float damageToShakeScale = 0.2f;

	public PlayerManager playerM;

	private Camera cam;
	private Vector3 originalCameraPosition;
	private float shakeAmt;

	void Start() {
		playerM.eventManager.GetEvent(PlayerEvents.WasHit).AddListener(WasHit);

		cam = this.GetComponent<Camera>();
	}

	void WasHit(float dmg) {
		shakeAmt = dmg * damageToShakeScale;
		// shakeAmt = coll.relativeVelocity.magnitude * .0035f;
		originalCameraPosition = new Vector3(this.transform.position.x, this.transform.position.y, -10);
		InvokeRepeating("CameraShaker", 0, .01f);
		Invoke("StopShaking", 0.3f);
	}

	void CameraShaker() {
		if (shakeAmt > 0) {
			float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
			Vector3 pp = cam.transform.position;
			pp.y += quakeAmt; // can also add to x and/or z
			cam.transform.position = pp;
		}
	}

	void StopShaking() {
		CancelInvoke("CameraShaker");
		cam.transform.position = originalCameraPosition;
	}

	//credits: http://newbquest.com/2014/06/the-art-of-screenshake-with-unity-2d-script/
}
