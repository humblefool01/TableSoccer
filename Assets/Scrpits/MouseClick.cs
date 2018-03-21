using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {

	private Rigidbody rb;

	private Vector3 dragOrigin;
	public float dragSpeed;
	public float force;
	public float maxDistance;
	public float factor;
	public float u;
	bool click;
	public GameObject player1, player2;
	//bool firstPlayer;

	void Start () {
		click = false;
		//firstPlayer = true;
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButtonDown (0)) {
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.name == "Player") {
					click = true;
					Debug.Log (hit.collider.name);
				} else
					click = false;
			}
			dragOrigin = Input.mousePosition;
		}
		//if (Input.GetMouseButton (0)) {
		//	if (Physics.Raycast(ray, out hit) && click){
		//		Vector3 pos = Camera.main.ScreenToViewportPoint (Input.mousePosition - dragOrigin);
		//		Vector3 move = new Vector3 (pos.y * dragSpeed, 0, -pos.x * dragSpeed);
				//transform.Translate (move, Space.World);
		//	}
		//}
		if (Input.GetMouseButton(0) && click){
			Vector3 mousePoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Debug.DrawLine (transform.position, mousePoint, Color.yellow);
		}
		if (Input.GetMouseButtonUp (0) && click) {
			Debug.Log (transform.position);
			Debug.Log ("Mouse released");
			Vector3 mousePoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Debug.Log (mousePoint);
			float distance = Vector3.Distance (transform.position, mousePoint);
			Debug.Log (distance);

			if (distance <= maxDistance) {
				Debug.Log ("Less than max");
				rb.AddForce ((transform.position.x - mousePoint.x) * force, 0, (transform.position.z - mousePoint.z) * force);
			} else {
				Debug.Log ("More than max");
				rb.AddForce ((transform.position.x - mousePoint.x) * force / factor , 0, (transform.position.z - mousePoint.z) * force / factor);
			}
			//firstPlayer = firstPlayer == true ? firstPlayer = false : firstPlayer = true;
		}
		//Debug.Log (rb.velocity);
		if (rb.velocity.magnitude >= 0.05f) {
			rb.AddForce ((-rb.velocity)*1*9.81f*u);
			Debug.Log ("Friction force acting");
		}
	}
}
