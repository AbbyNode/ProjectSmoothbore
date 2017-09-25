using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController2 : MonoBehaviour {

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float hMove = Input.GetAxis("Horizontal");
		float vMove = Input.GetAxis("Vertical");

		Debug.Log(hMove / vMove);

		float direction = Mathf.Tan(hMove / vMove);

//		Debug.Log(direction);

		// rb.rotation = direction;
	}

}
