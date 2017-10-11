using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankShellController : MonoBehaviour {
    public float shellSpeed = 5.0f;

    private Rigidbody2D rbody;
	// Use this for initialization
	void Start () {
        rbody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rbody.velocity = this.transform.right * shellSpeed;
	}
}
