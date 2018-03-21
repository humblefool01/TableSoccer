using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FirstPlayerController : MonoBehaviour {
	public float factor;
	private Rigidbody rb;
	void Start () {
		 rb = GetComponent<Rigidbody> ();
	}
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			Debug.Log ("A detected");
			if (gameObject.transform.position.z < 5.0f) {
				gameObject.transform.Translate (Vector3.forward * factor, Space.World);
			}
		}
		if (Input.GetKey (KeyCode.D)) {
			Debug.Log ("D detected");
			if (gameObject.transform.position.z > 1.0f) {
				gameObject.transform.Translate (-Vector3.forward * factor, Space.World);
			}
		}
		if (Input.GetKey (KeyCode.W)) {
			Debug.Log ("W detected");
			if (gameObject.transform.position.y < 3.5f) {
				gameObject.transform.Translate (Vector3.up * factor, Space.World);
			}
		}
		if (Input.GetKey (KeyCode.S)) {
			Debug.Log ("S detected");
			if (gameObject.transform.position.y > 0.5f) {
				gameObject.transform.Translate (-Vector3.up * factor, Space.World);
			}
		}
	}
}
