using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour {
	private Rigidbody rb;
	public float speed, u;
	private float moveHorizontal, moveVertical;
	void Start(){
		rb = GetComponent<Rigidbody> ();
	}
	void Update(){
		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");
		//Vector3 movement = new Vector3 (moveVertical, 0.0f, -moveHorizontal);
		//rb.AddForce (movement * speed);
		if (Input.GetKey(KeyCode.LeftArrow)){
			rb.transform.Translate (-0.2f, 0, 0);
		}
		if (Input.GetKey(KeyCode.RightArrow)){;
			rb.transform.Translate (0.2f, 0, 0);
		}
		if (Input.GetKey(KeyCode.UpArrow)){
			rb.transform.Translate (0f, 0, 0.2f);
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			rb.transform.Translate (0f, 0, -0.2f);
		}
	}
}
