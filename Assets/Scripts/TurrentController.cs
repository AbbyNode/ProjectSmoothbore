using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentController : MonoBehaviour
{

    public GameObject tankShell;
    public float fireDelta = 0.5f;
    public Transform spawnPoint;


    private float nextFire = 0.5f;
    private GameObject newtankShell;
    private float myTime = 0.0f;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            newtankShell = Instantiate(tankShell, transform.position, transform.rotation) as GameObject;

            // create code here that animates the newProjectile
          



            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }
}
