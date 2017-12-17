using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSlider : StatSlider {
	private void Start() {
		this.Init(PlayerEvents.HealthChanged);
	}
    Quaternion rotation;
    Vector3 position;
  
    private void Awake()
    {
        rotation = transform.rotation;
        position = transform.parent.position - transform.position;
    }
    private void Update()
    {
        this.transform.rotation = rotation;
        this.transform.position = transform.parent.position - position;

    }
}
