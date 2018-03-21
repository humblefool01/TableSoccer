using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cube_Controller : MonoBehaviour {
	private GameObject obj;
	private Rigidbody rb;
	public float speed;
	private bool jump;
	float moveHorizontal,moveVertical;
	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
		moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
		jump = Input.GetKey(KeyCode.Space);
		if(jump){
			transform.Translate (Vector3.up * 100* Time.deltaTime, Space.World);
		}
	}

}