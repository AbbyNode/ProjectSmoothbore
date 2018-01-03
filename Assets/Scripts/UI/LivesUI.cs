using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {
	public PlayerManager playerM;

	private Text livesUI;

	void Start() {
		this.livesUI = this.GetComponent<Text>();
        livesUI.text = "Lives: " + playerM.health.lives;

		EventManager eventM = playerM.eventManager;
		eventM.GetEvent(PlayerEvents.WasKilled).AddListener((lives) => livesUI.text = "Lives: " + lives);
        eventM.GetEvent(PlayerEvents.Lost).AddListener((lives) => livesUI.text = "Out of Lives!");
    }
}
