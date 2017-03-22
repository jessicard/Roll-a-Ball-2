using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject lossPanel;
	public GameObject pausePanel;

	private bool paused = false;

	void Update() {
		if (paused == true) {
			if (Input.anyKeyDown == true) {
				paused = false;
				Time.timeScale = 1;
				pausePanel.SetActive (false);
			}
		} else {
			if (Input.GetKeyDown ("escape")) {
				Time.timeScale = 0;
				pausePanel.SetActive (true);
				paused = true;
			}
		}
	}

	public void TriggerLoss () {
		StartCoroutine( LoadMenu() );
	}

	IEnumerator LoadMenu () {
		lossPanel.SetActive (true);
		yield return new WaitForSeconds (3.0f);
		SceneManager.LoadScene("Menu");
	}
}
