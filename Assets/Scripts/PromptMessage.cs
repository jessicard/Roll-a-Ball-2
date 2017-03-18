using System.Collections;
using System.Collections.Generic;

public class PromptMessage {
	public enum MessageType { Computer, User, Hijack }
	public MessageType messageType;
	public string messageContent;

	public PromptMessage (MessageType messageType, string messageContent = null) {
		this.messageType = messageType;
		this.messageContent = messageContent;
	}
}
