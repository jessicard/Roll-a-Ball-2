using System.Collections;
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

	private List<PromptMessage> scriptMessages;
	private int messageIndex = 0;
	private int hijackCharIndex = 0;
	private bool hijackInput = false;
	private PromptMessage currentMessage;

	void Start () {
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
		if (messageIndex < scriptMessages.Count) {
			transcriptComponent.text = messageContainer.text;
			ProcessReply ();
		}
	}

	void ProcessReply() {
		messageIndex = messageIndex + 1;

		currentMessage = scriptMessages [messageIndex];
		transcriptComponent.text = transcriptComponent.text + "\n";

		messageContainer.ActivateInputField ();
		messageContainer.text = "";

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
				// TODO: Load next real scene
				SceneManager.LoadScene ("Level1");
			} else if (Input.anyKey) {
				messageContainer.text = currentMessage.messageContent;
			}
		}
	}

	void HijackUserInput() {
		hijackCharIndex = hijackCharIndex + 1;
		messageContainer.text = new string (currentMessage.messageContent.ToCharArray (), 0, hijackCharIndex);
	}

	IEnumerator TypeText (string messageContent) {
		foreach (char letter in messageContent.ToCharArray()) {
			transcriptComponent.text += letter;
			yield return new WaitForSeconds (letterPause);
		}
		ProcessReply ();
	}
}
