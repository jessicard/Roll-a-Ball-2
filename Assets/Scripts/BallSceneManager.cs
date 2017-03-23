using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class BallSceneManager : MonoBehaviour {
	public GameObject levelHeader;

	void Start () {
		MusicManager.Play ("Audio/Analog-Nostalgia");

		if (SceneManager.GetActiveScene ().name != "Level1") {
			levelHeader.SetActive (true);
			Transform textTransform = levelHeader.transform.FindChild ("Text");

			textTransform.GetComponent<Text>().text = textTransform.GetComponent<Text>().text + " " + SceneManager.GetActiveScene().buildIndex.ToString(); 

			// TODO: Pause gameplay
			Invoke("DismissLevelHeader", 2);
		}
	}

	void DismissLevelHeader() {
		levelHeader.SetActive (false);
	}

	public static void TriggerNextBallLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
