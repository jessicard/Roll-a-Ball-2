using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
	static private MusicManager instance;

	static public MusicManager GetInstance() {
		if (instance == null) {
			GameObject gameObject = new GameObject();
			DontDestroyOnLoad (gameObject);

			gameObject.AddComponent<AudioSource>();
			gameObject.AddComponent<MusicManager>();

			instance = gameObject.GetComponent<MusicManager>();	
		}

		return instance;
	}

	public void Play(string path) {
		AudioClip audioClip = Resources.Load<AudioClip> (path);

		if (!audioClip) {
			Debug.Log ("Audio clip does not exist at this path.");
			return;
		}
		
		if (!this.GetComponent<AudioSource>().clip || (this.GetComponent<AudioSource>().clip.name != audioClip.name)) {
			this.GetComponent<AudioSource>().clip = audioClip;
			this.GetComponent<AudioSource>().Play ();
		}
	}
}
