using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Try : MonoBehaviour {
	private Rigidbody rb;
	private float moveHorizontal, moveVertical, jump;
	public float speed, factor;
	private Vector3 movement;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}
	void Update(){
		/*moveHorizontal = Input.GetAxis ("Horizontal");
		moveVertical = Input.GetAxis ("Vertical");
		movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement*speed);*/
		if(Input.GetKey(KeyCode.UpArrow)){
			gameObject.transform.Translate(0.0f,0.0f,speed*Time.deltaTime);
		}		
		if(Input.GetKey(KeyCode.DownArrow)){
			gameObject.transform.Translate(0.0f,0.0f,-speed*Time.deltaTime);
		}		
		if(Input.GetButtonDown("Jump")){
			Debug.Log ("Force Added");
			rb.AddForce (0.0f, factor, 0.0f);
		//gameObject.transform.Translate(0.0f, factor*Time.deltaTime, 0.0f);
		}
	}
}
