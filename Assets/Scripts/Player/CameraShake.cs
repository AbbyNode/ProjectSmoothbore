using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : CameraController {
    Vector3 originalCameraPosition;

    public float shakeAmt = 0;

    public Camera mainCamera;
    // Use this for initialization
    void Start () {

       // originalCameraPosition = new Vector3(this.transform.position.x, this.transform.position.y, -10);
 
    }

	
	// Update is called once per frame
	void Update () {    
        originalCameraPosition = new Vector3(this.transform.position.x, this.transform.position.y, -10);


    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag=="Shell")
        {
            shakeAmt = coll.relativeVelocity.magnitude * .0035f;
            InvokeRepeating("CameraShaker", 0, .01f);
            Invoke("StopShaking", 0.3f);
        }
        

    }

    void CameraShaker()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.y += quakeAmt; // can also add to x and/or z
            mainCamera.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShaker");
        mainCamera.transform.position = originalCameraPosition;
    }
    //credits: http://newbquest.com/2014/06/the-art-of-screenshake-with-unity-2d-script/
}
