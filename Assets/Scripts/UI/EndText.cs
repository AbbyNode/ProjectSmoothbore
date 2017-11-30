using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndText : MonoBehaviour {
	public PlayerManager playerM;

	private Text endText;

	void Start() {
		this.endText = this.GetComponent<Text>();

		EventManager eventM = playerM.eventManager;
		eventM.GetEvent(PlayerEvents.Died).AddListener((f) => endText.text = "You lose!");
	}
}
