using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour {
	void Start() {
		this.GetComponent<Text>().text = "Congratulations! Player " + GameManager.winner + " won!";
	}
}
