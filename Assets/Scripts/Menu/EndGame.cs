using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	public Button endButton;

	void Start () {
		Button btn = endButton.GetComponent<Button>();
		btn.onClick.AddListener(QuitGame);
	}

	void QuitGame () {
		Application.Quit();
	}
}
