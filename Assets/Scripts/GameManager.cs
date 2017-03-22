using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject lossPanel;

	void Update() {
		if (Input.GetKey ("escape")) {
			// TODO: Check if they're sure they want to quit
			SceneManager.LoadScene("Menu");
		}

		if (Input.GetKey ("space")) {
			// TODO: Space bar to pause the game
			Debug.Log("pause");
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
