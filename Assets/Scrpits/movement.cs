using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private float moveH, moveV; 
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		moveH = Input.GetAxis ("Horizontal");
		moveV = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveH, 0.0f, moveV);
		rb.AddForce (movement*speed);
	}
}
