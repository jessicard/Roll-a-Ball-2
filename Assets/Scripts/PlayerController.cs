using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public GameObject levelHeader;

	public GameObject music;

	private Rigidbody rb;
	private GameObject[] pickUpObjs;
	private int count;

	void Awake()
	{
		if (music != null) {
			music.transform.GetComponent<AudioSource> ().Play ();
			DontDestroyOnLoad (music);
		}
	}

	void Start() {
		if (SceneManager.GetActiveScene ().name != "Level1") {
			levelHeader.SetActive (true);
			Transform textTransform = levelHeader.transform.FindChild ("Text");

			textTransform.GetComponent<Text>().text = textTransform.GetComponent<Text>().text + " " + SceneManager.GetActiveScene().buildIndex.ToString(); 

			// TODO: Pause gameplay
			Invoke("DismissLevelHeader", 2);
		}
			
		pickUpObjs = GameObject.FindGameObjectsWithTag ("Pick Up");
		rb = GetComponent<Rigidbody>();
		count = 0;

		SetCountText ();
	}
		
	void DismissLevelHeader() {
		levelHeader.SetActive (false);
	}

	void Update() {
		if (Input.GetKey ("escape")) {
			SceneManager.LoadScene("_Menu");
		}
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
			SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}
}
