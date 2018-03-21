using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower_script : MonoBehaviour {

	public GameObject cube;
	private Vector3 movement;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
	}
	void Update(){
		movement = cube.transform.position;
		movement.x += 50;
		gameObject.transform.position = movement;
	}
}
