using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
	static private MusicManager instance;

	static void SetInstance() {
		GameObject gameObject = new GameObject();
		DontDestroyOnLoad (gameObject);

		gameObject.AddComponent<AudioSource>();
		gameObject.AddComponent<MusicManager>();

		instance = gameObject.GetComponent<MusicManager>();	
	}

	static public void Play(string path) {
		AudioClip audioClip = Resources.Load<AudioClip> (path);

		if (!audioClip) {
			Debug.Log ("Audio clip does not exist at this path.");
			return;
		}

		if (!instance) {
			SetInstance ();
		}
		
		if (!instance.GetComponent<AudioSource>().clip || (instance.GetComponent<AudioSource>().clip.name != audioClip.name)) {
			instance.GetComponent<AudioSource>().clip = audioClip;
			instance.GetComponent<AudioSource>().Play ();
		}
	}
}
