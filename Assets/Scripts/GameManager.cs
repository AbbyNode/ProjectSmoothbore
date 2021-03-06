﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public const string mainMenuScene = "MainMenu";
	public const string winScene = "WinScene";
	public const string map1Scene = "Map1";
	public const string map2Scene = "Map2";
	public const string map3Scene = "Map3";
	public const string controlsScene = "Controls";

	public static int winner;

	public List<PlayerManager> players;

	void Start() {
		foreach (PlayerManager playerM in players) {
			playerM.eventManager.GetEvent(PlayerEvents.Lost).AddListener((playerNum) => {
				players.Remove(playerM);
				if (players.Count == 1) {
					winner = players[0].playerNum + 1;
					SceneManager.LoadScene(winScene);
				}
			});
		}
	}
}
