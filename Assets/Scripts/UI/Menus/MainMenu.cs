using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public Button map1Button;
	public Button map2Button;
    public Button map3Button;
    public Button controlsButton;

    void Start() {
		map1Button.onClick.AddListener(() => {
			SceneManager.LoadScene(GameManager.map1Scene);
		});

		map2Button.onClick.AddListener(() => {
			SceneManager.LoadScene(GameManager.map2Scene);
		});
        map3Button.onClick.AddListener(() => {
            SceneManager.LoadScene(GameManager.map3Scene);
        });
        controlsButton.onClick.AddListener(() => {
            SceneManager.LoadScene(GameManager.controlsScene);
        });
    }
}
