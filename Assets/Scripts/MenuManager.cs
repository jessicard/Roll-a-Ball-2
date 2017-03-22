using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public Button startButton;
	public Button exitButton;

	void Awake() {
		// TODO: Turn off any other music playing
	}

	void Start () {
		Button startBtn = startButton.GetComponent<Button>();
		Button exitBtn = exitButton.GetComponent<Button>();

		startBtn.onClick.AddListener(LoadLevel);
		exitBtn.onClick.AddListener(QuitGame);
	}

	void LoadLevel () {
		SceneManager.LoadScene("Level1");
	}

	void QuitGame () {
		Application.Quit();
	}
}
