using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Prompt : MonoBehaviour {
	public float letterPause = 0.2f;

	public Text textComponent;

	// Use this for initialization
	void Start () {
		textComponent = GetComponent<Text>();
		textComponent.text = "";
		List<PromptMessage> scriptMessages = new List<PromptMessage> ();

		scriptMessages.Add (new PromptMessage (PromptMessage.MessageType.Computer, "Testing"));
		scriptMessages.Add (new PromptMessage (PromptMessage.MessageType.User));
		scriptMessages.Add (new PromptMessage (PromptMessage.MessageType.Hijack, "Testing2222222"));

		foreach (PromptMessage message in scriptMessages) {
			switch (message.messageType) {
			case PromptMessage.MessageType.Computer:
				StartCoroutine (TypeText (message.messageContent));
				break;
			case PromptMessage.MessageType.User:
				break;
			case PromptMessage.MessageType.Hijack:	
				break;
			}
		}
	}

	IEnumerator TypeText (string messageContent) {
		foreach (char letter in messageContent.ToCharArray()) {
			textComponent.text += letter;

			yield return new WaitForSeconds (letterPause);
		}
	}
}
