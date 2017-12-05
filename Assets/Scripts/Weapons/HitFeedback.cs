using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedback : ShellController {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
	}

    public GameObject SparkAni;
    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject test = Instantiate(SparkAni, this.transform.position, this.transform.rotation) as GameObject;

        Destroy(test,1);

    }
}
