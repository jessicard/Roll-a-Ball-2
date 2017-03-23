using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;

	private Rigidbody rb;
	private GameObject[] pickUpObjs;
	private int count;

	void Start() {
		pickUpObjs = GameObject.FindGameObjectsWithTag ("Pick Up");
		rb = GetComponent<Rigidbody>();
		count = 0;

		SetCountText ();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText() {
		countText.text = "Count: " + count.ToString ();

		if (count == pickUpObjs.Length) {
			BallSceneManager.TriggerNextBallLevel ();
		}
	}
}
