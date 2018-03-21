using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMovement : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	private Vector3 position;
	private float left;
	private float right; 
	private float front;
	private bool flag;
	void Start () {
		rb = GetComponent<Rigidbody>();
		position = rb.transform.position;
		flag = true;

	}

	void FixedUpdate () {
		if(flag){
			rb.transform.position += transform.forward * Time.deltaTime * speed;	//Auto forward movement
		}
		//Ray right = new Ray (transform.position, Vector3.right);
		RaycastHit hitLeft;
		RaycastHit hitRight;
		RaycastHit forward;
		if(Physics.Raycast(rb.transform.position, Vector3.forward, out hitLeft, 5.0f)){		//Left wall raycast
			//Debug.Log (hitLeft.transform.name +"  "+ hitLeft.distance);
			left = hitLeft.distance;
		}
		if(Physics.Raycast(rb.transform.position, -Vector3.forward, out hitRight, 5.0f)){	//Right wall raycast
			//Debug.Log (hitRight.transform.name +"  "+ hitRight.distance);
			right = hitRight.distance;
		}
		if(Physics.Raycast(rb.transform.position, Vector3.right, out forward, 5.0f)){		//Front wall raycast
			//Debug.Log (forward.transform.name +"  "+ forward.distance);
			front = forward.distance;
			Debug.Log (forward.transform.name);
		}
		if (front > 4.5f) {
			Debug.Log ("object ahead");
			if (right <= left) {
				rb.transform.position += transform.right * Time.deltaTime * speed;
			}
		} 
	}
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Walls"){
			rb.transform.position = position;
			flag = false;
			Debug.Log(flag);
		}
	}
}
