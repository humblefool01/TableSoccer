using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friction : MonoBehaviour {

	private Rigidbody rb;
	public float u;
	private Vector3 startPos;
	void Start () {
		rb = GetComponent<Rigidbody> ();
		startPos = new Vector3(0f, 0.5f, 0f);
	}

	void Update () {
		if (rb.velocity.magnitude >= 0.05f) {
			rb.AddForce ((-rb.velocity)*1*9.81f*u);
		}
		if (rb.transform.position.x >= 21f && rb.velocity.magnitude <= 0f) {
			rb.transform.position = new Vector3(21f, rb.transform.position.y, rb.transform.position.z);
		}
		if (rb.transform.position.x <= -21f && rb.velocity.magnitude <= 0f) {
			rb.transform.position = new Vector3(-21f, rb.transform.position.y, rb.transform.position.z);
		}
		if (rb.transform.position.z >= 46f && rb.velocity.magnitude <= 0f) {
			rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, 46f);
		}
		if (rb.transform.position.z <= -46f && rb.velocity.magnitude <= 0f) {
			rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, -46f);
		}
	}
//	IEnumerator OnTriggerEnter(Collider col){
//		Debug.Log ("Trigger");
//		if (col.gameObject.name == "GoalPost" || col.gameObject.name == "GoalPost2") {
//			Debug.Log ("Goal!");
//			//gameObject.transform.position = new Vector3 (100f, 0f, 100f);
//			yield return new WaitForSeconds(0.5f);
//			//gameObject.transform.position = new Vector3 (0f, 0.5f, 0f);
//			//rb = gameObject.GetComponent<Rigidbody> ();
//			//rb.velocity = Vector3.zero;
//		}
//	}
}
