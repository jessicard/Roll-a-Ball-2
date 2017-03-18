using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public Button startButton;

	void Start () {
		Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(LoadLevel);
	}

	void LoadLevel () {
		SceneManager.LoadScene("Level1");
	}
}
