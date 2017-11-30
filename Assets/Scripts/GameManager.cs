using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject[] players;
	private PlayerManager playerM;

	// Use this for initialization
	void Start() {
		players = GameObject.FindGameObjectsWithTag("Player");
		EventManager eventM = playerM.eventManager;

		//for (int i = 0; i < players.Length; i++)
		//{
		//    if (players[i] == null)
		//    {
		eventM.GetEvent("PlayerDeath").AddListener(DeathCount);
		//    }
		//}
	}

	void DeathCount(float f) {
		players = GameObject.FindGameObjectsWithTag("Player");

		Debug.Log("someone died");
		if (players.Length == 1) {
			SceneManager.LoadScene("WinScene");
		}
	}
}
