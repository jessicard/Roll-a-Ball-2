using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class BallSceneManager : MonoBehaviour {
	public GameObject levelHeader;
	public static int levelHeaderDelay = 2;

	void Start () {
		MusicManager.Play ("Audio/Analog-Nostalgia");

		if (SceneManager.GetActiveScene ().name != "Level1") {
			levelHeader.SetActive (true);
			Transform textTransform = levelHeader.transform.FindChild ("Text");

			textTransform.GetComponent<Text>().text = textTransform.GetComponent<Text>().text + " " + SceneManager.GetActiveScene().buildIndex.ToString(); 

			Invoke("DismissLevelHeader", levelHeaderDelay);
		}
	}

	void DismissLevelHeader() {
		levelHeader.SetActive (false);
	}

	public static void TriggerNextBallLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
