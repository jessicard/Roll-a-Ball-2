using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Prompt : MonoBehaviour {
	public float letterPause = 0.2f;
	public Text textComponent;
	public InputField textField;

	void Start () {
		textComponent.text = "";
		textField.ActivateInputField();

//		textField.onValueChanged.AddListener (delegate {ValueChangeCheck ();});

		List<PromptMessage> scriptMessages = new List<PromptMessage> ();

		scriptMessages.Add (new PromptMessage (PromptMessage.MessageType.Computer, "Testing"));
		scriptMessages.Add (new PromptMessage (PromptMessage.MessageType.User));
		scriptMessages.Add (new PromptMessage (PromptMessage.MessageType.Hijack, "Testing2222222"));

//		foreach (PromptMessage message in scriptMessages) {
//			switch (message.messageType) {
//			case PromptMessage.MessageType.Computer:
//				StartCoroutine (TypeText (message.messageContent));
//				break;
//			case PromptMessage.MessageType.User:
//				textComponent.text = textComponent.text + "\n";
//				if (Input.GetKeyDown (KeyCode.Return)) {
//				} else {
//					textTransform.GetComponent<Text>().text = textTransform.GetComponent<Text>().text + Input.inputString;
//				}
//				break;
//			case PromptMessage.MessageType.Hijack:	
//				break;
//			}
//		}
	}

//	void ValueChangeCheck () {
//		textField.text = textField.text + "1";
//	}
		

//	IEnumerator TypeText (string messageContent) {
//		foreach (char letter in messageContent.ToCharArray()) {
//			textTransform.GetComponent<Text>().text += letter;
//
//			yield return new WaitForSeconds (letterPause);
//		}
//	}
}
