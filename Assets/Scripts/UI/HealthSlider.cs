using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : StatSlider {
    Quaternion rotation;
    Vector3 position;
    float timeSinceHit;
    public Image background, fill;

    private void Start() {
        playerM.eventManager.GetEvent(PlayerEvents.WasHit).AddListener(ShowUI);
        this.Init(PlayerEvents.HealthChanged);
    }

    private void Awake() {
        rotation = transform.rotation;
        position = transform.parent.position - transform.position;
    }

    private void Update() {
        this.transform.rotation = rotation;
        this.transform.position = transform.parent.position - position;
        timeSinceHit += Time.deltaTime;
        if (timeSinceHit >= 3) {
            FadeUI();
        }
    }

    private void FadeUI() {
        background.CrossFadeAlpha(0, 1, false);
        fill.CrossFadeAlpha(0, 1, false);
    }

    private void ShowUI(float x) {
        timeSinceHit = 0;
        background.CrossFadeAlpha(1, 0, false);
        fill.CrossFadeAlpha(1, 0, false);
    }
}
