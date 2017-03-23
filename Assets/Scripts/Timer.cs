using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public int timerSeconds;
	public Text timerText;

	void Start () {
		timerText.text = timerSeconds.ToString ();

		Invoke("StartTimer", (BallSceneManager.levelHeaderDelay + 1));
	}

	void StartTimer() {
		InvokeRepeating ("IncrementTimer", 0f, 1.0f);
	}
	
	void IncrementTimer() {
		timerText.text = (int.Parse (timerText.text) - 1).ToString ();

		if (timerText.text == "0") {
			GameObject.Find("GameManager").GetComponent<GameManager>().TriggerLoss ();
		}
	}
}
