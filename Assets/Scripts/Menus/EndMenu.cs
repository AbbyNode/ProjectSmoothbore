using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour {
	public Button playAgainButton;

	void Start() {
		playAgainButton.onClick.AddListener(() => {
			SceneManager.LoadScene(GameManager.mainMenuScene);
		});
	}
}
