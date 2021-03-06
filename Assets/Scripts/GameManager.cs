﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject lossPanel;
	public GameObject pausePanel;

	public Button unpauseButton;
	public Button menuButton;

	private bool paused = false;

	void Start() {
		Button unpauseBtn = unpauseButton.GetComponent<Button>();
		Button menuBtn = menuButton.GetComponent<Button>();

		unpauseBtn.onClick.AddListener(UnpauseGame);
		menuBtn.onClick.AddListener(QuitToMenu);
	}

	void Update() {
		if (Input.GetKeyDown ("escape")) {
			if (paused == false) {
				Time.timeScale = 0;
				pausePanel.SetActive (true);
				paused = true;
			} else {
				UnpauseGame ();
			}
		}
	}

	public void TriggerLoss () {
		StartCoroutine( DisplayLossPanel() );
	}

	void UnpauseGame () {
		paused = false;
		Time.timeScale = 1;
		pausePanel.SetActive (false);
	}

	void QuitToMenu () {
		SceneManager.LoadScene("Menu");
	}

	IEnumerator DisplayLossPanel () {
		lossPanel.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		QuitToMenu ();
	}
}
