﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Prompt : MonoBehaviour {
	public float letterPause;
	public float computerResponsePause;
	public Text transcriptComponent;
	public Text messageText;
	public InputField messageContainer;
	public GameObject typeSound;

	private List<PromptMessage> scriptMessages;
	private int messageIndex = 0;
	private int hijackCharIndex = 0;
	private bool hijackInput = false;
	private PromptMessage currentMessage;

	void Start () {
		MusicManager.Play ("Audio/MechDrone1");

		transcriptComponent.text = "";

		messageContainer.ActivateInputField();
		SetUpScript ();

		messageContainer.onEndEdit.AddListener(delegate { OnSubmitMessage(); });
	}

	void SetUpScript() {
		scriptMessages = new List<PromptMessage> ();

		scriptMessages.Add (new PromptMessage (PromptMessage.MessageType.User));
		scriptMessages.Add (new PromptMessage (PromptMessage.MessageType.Computer, "Testing"));
		scriptMessages.Add (new PromptMessage (PromptMessage.MessageType.Hijack, "Testing2222222"));
	}

	void OnSubmitMessage () {
		if (Input.GetMouseButtonDown(0) 
			|| Input.GetMouseButtonDown(1)
			|| Input.GetMouseButtonDown(2))
			return;

		// TODO: Don't allow submission on hijack if the full message hasnt been typed
//		if (currentMessage.messageType == PromptMessage.MessageType.Hijack &&
//		    currentMessage.messageContent.Length > messageText.text.Length)
//			return;
		
		transcriptComponent.text = transcriptComponent.text + messageContainer.text;

		if (messageIndex < scriptMessages.Count) {
			ProcessReply ();
		}
	}

	void ProcessReply() {
		messageIndex = messageIndex + 1;

		currentMessage = scriptMessages [messageIndex];
		transcriptComponent.text = transcriptComponent.text + "\n";

		messageContainer.ActivateInputField ();
		messageContainer.text = "";

//		float newMessageContainerPosY = -(transcriptComponent.transform.GetComponent<RectTransform>().rect.height) - 10;
//		Vector3 newMessageContainerPosY = messageContainer.transform.GetComponent<RectTransform>().position;

		Debug.Log (newMessageContainerPosY);

//		messageContainer.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3 (0, newMessageContainerPosY, 0);

		switch (currentMessage.messageType) {
		case PromptMessage.MessageType.Computer:
			// TODO: Disallow typing while computer is replying
			StartCoroutine( ReplyAsComputer() );
			break;
		case PromptMessage.MessageType.User:
			// Do nothing.
			break;
		case PromptMessage.MessageType.Hijack:
			hijackInput = true;
			break;
		}
	}

	private IEnumerator ReplyAsComputer() {
		yield return new WaitForSeconds( computerResponsePause );
		StartCoroutine (TypeText (currentMessage.messageContent));
	}

	void Update() {
		if (Input.anyKeyDown) {
			if (Input.GetMouseButtonDown(0) 
				|| Input.GetMouseButtonDown(1)
				|| Input.GetMouseButtonDown(2))
				return;

			// TODO: Don't allow typing noises on hijack if the full message has been typed
			typeSound.transform.GetComponent<AudioSource> ().Play ();
		}

		if (hijackInput == true && hijackCharIndex < messageContainer.text.Length) {
			if ((hijackCharIndex + 1) == currentMessage.messageContent.Length) {
				hijackInput = false;
				messageContainer.text = currentMessage.messageContent;
				ProcessReply ();
			} else {
				HijackUserInput ();
			}
		}

		if (messageIndex >= scriptMessages.Count) {
			if (Input.GetKeyDown ("return")) {
				StartCoroutine( StartNextScene() );
			} else if (Input.anyKeyDown) {
				if (Input.GetMouseButtonDown(0) 
					|| Input.GetMouseButtonDown(1)
					|| Input.GetMouseButtonDown(2))
					return;
				
				messageContainer.text = currentMessage.messageContent;
			}
		}
	}

	void HijackUserInput() {
		hijackCharIndex = hijackCharIndex + 1;
		messageContainer.text = new string (currentMessage.messageContent.ToCharArray (), 0, hijackCharIndex);
	}

	IEnumerator StartNextScene () {
		// TODO: Fix this. Needs to clear inputField text when scene prompt scene ends
		messageContainer.text = "";

		yield return new WaitForSeconds (3.0f);

		// TODO: Load next real scene
		SceneManager.LoadScene ("Level1");
	}

	IEnumerator TypeText (string messageContent) {
		foreach (char letter in messageContent.ToCharArray()) {
			transcriptComponent.text += letter;
			typeSound.transform.GetComponent<AudioSource> ().Play ();
			yield return new WaitForSeconds (letterPause);
		}
		ProcessReply ();
	}
}
