using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    Rigidbody2D rb;
    public float movementSpeed;
    public float rotateSpeed;
    public GameObject shellObject;
    private float nextfire;
    public Transform spawnPoint;
    public float shootForce;

    GameObject bullet;
    GameObject bore;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        bore = GameObject.Find("bore");

        nextfire = Time.time + 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, movementSpeed, 0);
            // moving this gameobject upward by increasing position y.
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -movementSpeed, 0);
            // moving this gameobject upward by decreasing position y.
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotateSpeed);
            //rotating the tank to the left
         
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotateSpeed);
            //rotating the the tank to the right
           
        }
        if (Input.GetKey(KeyCode.E))
        {      
            bore.transform.Rotate(0, 0, -rotateSpeed);
            // tank gun rotation or aiming to the left
        }
        if (Input.GetKey(KeyCode.Q))
        {
            bore.transform.Rotate(0, 0, rotateSpeed);
            //aiming to the right
        }
        if (Input.GetButton("Fire1") && Time.time > nextfire)
        {
            nextfire = Time.time + 1;
            Fire();
        }


    }
    void Fire()
    {
        bullet = Instantiate(shellObject, spawnPoint.position, spawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * 10;
        Destroy(bullet, 2.0f);

    }

}
