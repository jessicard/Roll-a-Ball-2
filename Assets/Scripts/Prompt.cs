using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Prompt : MonoBehaviour {
	public float letterPause = 0.2f;
	public Text transcriptComponent;
	public Text messageText;
	public InputField messageContainer;

	private List<PromptMessage> scriptMessages;
	private int messageIndex;

	void Start () {
		transcriptComponent.text = "";
		messageIndex = 0;

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
		messageIndex = messageIndex + 1;

		if (messageContainer.text.Length > 0) {
			if (transcriptComponent.text.Length > 0) {
				transcriptComponent.text = transcriptComponent.text + "\n" + messageContainer.text;
			} else {
				// Concat & newline unnecessary for the first message
				transcriptComponent.text = messageContainer.text;
			}
			messageContainer.text = "";
		}

		ProcessReply ();
	}

	void ProcessReply() {
		PromptMessage currentMessage = scriptMessages [messageIndex];

		switch (currentMessage.messageType) {
		case PromptMessage.MessageType.Computer:
			StartCoroutine (TypeText (currentMessage.messageContent));
			break;
		case PromptMessage.MessageType.User:
			messageContainer.ActivateInputField();
			break;
		case PromptMessage.MessageType.Hijack:	
			HijackUserInput ();
			break;
		}
	}

	void HijackUserInput() {
		messageIndex = messageIndex + 1;

		ProcessReply ();
	}
		

	IEnumerator TypeText (string messageContent) {
		messageIndex = messageIndex + 1;

		transcriptComponent.text = transcriptComponent.text + "\n";

		foreach (char letter in messageContent.ToCharArray()) {
			transcriptComponent.text += letter;

			yield return new WaitForSeconds (letterPause);
		}

		ProcessReply ();
	}
}
