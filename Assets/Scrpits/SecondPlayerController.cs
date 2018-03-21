using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerController : MonoBehaviour {
	public float factor;
	private Rigidbody rb;
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Debug.Log ("Left Arrow detected");
			if (gameObject.transform.position.z < -1.0f) {
				gameObject.transform.Translate (Vector3.forward * factor, Space.World);
			}
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			Debug.Log ("Right Arrow detected");
			if (gameObject.transform.position.z > -5.0f) {
				gameObject.transform.Translate (-Vector3.forward * factor, Space.World);
			}
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			Debug.Log ("Up Arrow detected");
			if (gameObject.transform.position.y < 3.5f) {
				gameObject.transform.Translate (Vector3.up * factor, Space.World);
			}
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			Debug.Log ("Down Arrow detected");
			if (gameObject.transform.position.y > 0.5f) {
				gameObject.transform.Translate (-Vector3.up * factor, Space.World);
			}
		}
	}
}

