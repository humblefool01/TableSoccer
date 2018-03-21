using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private Rigidbody rb, rigidBody;

	//public float dragSpeed;
	public float force, deltaTime = 0.0f;
	public float maxDistance;
	public float factor;
	public float u;
	bool click, resetText;
	private int red, blue;
	public GameObject player1, player2, ball, glass, line;
	private GameObject player;
	bool firstPlayer, win;
	private Transform[] t;
	private Rigidbody[] r;
	private LineRenderer lineRend;
	public Material lineMat;


	public Text redText, blueText, winText, restartText;
	void Start () {
		glass.SetActive (false);
		click = false;
		resetText = false;
		firstPlayer = true;
		win = false;
		rb = GetComponent<Rigidbody> ();
		lineRend = line.GetComponent<LineRenderer> ();
		red = 0;
		blue = 0;

	}

	void Update () {

//		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
//		float fps = 1.0f / deltaTime;
//		Debug.Log (fps);

		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}

		if (win == true && Input.GetKey (KeyCode.Space)) {
			SceneManager.LoadScene ("Scene 1");
		}
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast (ray, out hit)) {
				if ((hit.collider.gameObject.transform.parent.name == "Player" && firstPlayer) || (hit.collider.gameObject.transform.parent.name == "Player2" && !firstPlayer)) {
					click = true;
				} else {
					click = false;
				}
			}
			player = hit.collider.gameObject;
		}
			
			if (Input.GetMouseButton(0) && click && player != null){
				rigidBody = player.GetComponent<Rigidbody> ();	
				Vector3 mousePoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				DrawLine (rigidBody.transform.position, mousePoint);
				//Debug.DrawLine (rigidBody.transform.position, mousePoint, Color.yellow);
			}
			if (Input.GetMouseButtonUp (0) && click) {
				lineRend.enabled = false;
				Vector3 mousePoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				float distance = Vector3.Distance (player.transform.position, mousePoint);
				if (distance <= maxDistance) {
					rigidBody.AddForce ((player.transform.position.x - mousePoint.x) * force, 0, (player.transform.position.z - mousePoint.z) * force);
				} else {
					rigidBody.AddForce ((rigidBody.transform.position.x - mousePoint.x) * force / factor , 0, (rigidBody.transform.position.z - mousePoint.z) * force / factor);
				}
				firstPlayer = (firstPlayer == true ? firstPlayer = false : firstPlayer = true);
			}
			
		r = player1.GetComponentsInChildren<Rigidbody> ();
		foreach (Rigidbody child in r) {
			if (child.velocity.magnitude >= 0.01f)
				child.AddForce ((-child.velocity)*1*9.81f*u);
		}
		r = player2.GetComponentsInChildren<Rigidbody> ();
		foreach (Rigidbody child in r) {
			if (child.velocity.magnitude >= 0.01f)
				child.AddForce ((-child.velocity)*1*9.81f*u);
		}

		if (ball.transform.position.z >= 52f || ball.transform.position.z <= -52f) {
			score (ball, redText, blueText);
			reset (false);
		} else {
			r = player1.GetComponentsInChildren<Rigidbody> ();
			foreach (Rigidbody child in r) {
				if (child.transform.position.z >= 52f || child.transform.position.z <= -52f) {
					child.velocity = Vector3.zero;
					switch (child.name) {
					case "Player":
						child.transform.position = new Vector3 (0f, 1f, 20f);
						break;
					case "Player (1)":
						child.transform.position = new Vector3 (15f, 1f, 30f);
						break;
					case "Player (2)":
						child.transform.position = new Vector3 (-15f, 1f, 30f);
						break;
					}
				}
			}
			r = player2.GetComponentsInChildren<Rigidbody> ();
			foreach (Rigidbody child in r) {
				if (child.transform.position.z >= 52f || child.transform.position.z <= -52f) {
					child.velocity = Vector3.zero;
					switch (child.name) {
					case "Player2":
						child.transform.position = new Vector3 (0f, 1f, -20f);
						break;
					case "Player2 (1)":
						child.transform.position = new Vector3 (15f, 1f, -30f);
						break;
					case "Player2 (2)":
						child.transform.position = new Vector3 (-15f, 1f, -30f);
						break;
					}
				}
			}

		}
	}
	void reset(bool resetText){
		StartCoroutine (Sleep (2f));
		if (resetText){
			redText.text = ("RED:");
			blueText.text = ("BLUE:");
			winText.text = ("");
			firstPlayer = true;
		}
		ball.transform.position = new Vector3 (100f, 0f, 100f);

		foreach(Transform child in player1.transform){
			child.transform.position = new Vector3 (100f, 0f, 100f);
		}
		foreach(Transform child in player2.transform){
			child.transform.position = new Vector3 (100f, 0f, 100f);
		}

		rb = ball.GetComponent<Rigidbody> ();
		rb.velocity = Vector3.zero;
		ball.transform.position = new Vector3 (0f, 0.5f, 0f);

		r = player1.GetComponentsInChildren<Rigidbody> ();
		r [0].velocity = Vector3.zero;
		r [1].velocity = Vector3.zero;
		r [2].velocity = Vector3.zero;

		t = player1.GetComponentsInChildren<Transform> ();
		t [1].transform.position = new Vector3 (0f, 1f, 20f);
		t [2].transform.position = new Vector3 (15f, 1f, 30f);
		t [3].transform.position = new Vector3 (-15f, 1f, 30f);

		r = player2.GetComponentsInChildren<Rigidbody> ();
		r [0].velocity = Vector3.zero;
		r [1].velocity = Vector3.zero;
		r [2].velocity = Vector3.zero;

		t = player2.GetComponentsInChildren<Transform> ();
		t [1].transform.position = new Vector3 (0f, 1f, -20f);
		t [2].transform.position = new Vector3 (15f, 1f, -30f);
		t [3].transform.position = new Vector3 (-15f, 1f, -30f);

	}

	void score(GameObject ball, Text redText, Text blueText){
		if (ball.transform.position.z >= 52f) {
			blue += 1;
			blueText.text = ("BLUE:"+blue);
		} else if (ball.transform.position.z <= -52f) {
			red += 1;
			redText.text = ("RED:"+red);
		}
		if (red == 2) {
			winText.text = "Red Wins!";
			red = 0;
			blue = 0;
			win = true;
			glass.SetActive (true);
			restartText.text = "Press SPACE to restart";
			//reset (true);
		}
		if (blue == 2){
			winText.text = "Blue Wins!";
			red = 0;
			blue = 0;
			win = true;
			glass.SetActive (true);
			restartText.text = "Press SPACE to restart";
			//reset (true);
		}
	}

	void DrawLine (Vector3 start, Vector3 end){
		lineRend.enabled = true;
		start.y = 5f;
		end.y = 5f;
		lineRend.SetPosition(0, start);
		lineRend.SetPosition(1, end);
		lineRend.startWidth = 0.5f;
		lineRend.endWidth = 0.5f;
		lineRend.material = new Material (Shader.Find("Particles/Additive"));//Unlit/Texture
		lineRend.startColor = Color.yellow;
		lineRend.endColor = Color.yellow;
	}

	IEnumerator Sleep(float time){
		yield return new WaitForSeconds(time);
		Debug.Log ("Delay called");

	}
}
	