﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public Button startButton;
	public Button exitButton;

	void Start () {
		MusicManager.Play ("Audio/Disturbed-Soundscape");

		Button startBtn = startButton.GetComponent<Button>();
		Button exitBtn = exitButton.GetComponent<Button>();

		startBtn.onClick.AddListener(LoadFirstLevel);
		exitBtn.onClick.AddListener(QuitGame);
	}

	void Update() {
		if (Input.GetKey ("escape")) {
			QuitGame ();
		}
	}

	void LoadFirstLevel () {
		SceneManager.LoadScene("Level1");
	}

	void QuitGame () {
		Application.Quit();
	}
}
