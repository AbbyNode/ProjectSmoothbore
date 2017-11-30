using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public List<PlayerManager> players;

	void Start() {
		foreach (PlayerManager playerM in players) {
			playerM.eventManager.GetEvent(PlayerEvents.WasKilled).AddListener((playerNum) => {
				players.Remove(playerM);
				if (players.Count == 1) {
					int winner = players[0].playerNum + 1;
					SceneManager.LoadScene("WinScene");
				}
			});
		}
	}
}
