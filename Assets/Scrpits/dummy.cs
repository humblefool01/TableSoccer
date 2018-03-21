using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dummy : MonoBehaviour { 
	private Rigidbody rb;
	private int i = 0;
	private float[] arrx = new float[10];
	private float[] arry = new float[10];
	private float[] temp = new float[100];
	//private float[] tempy = new float[10];
	private int x = 0, y, j, k = 0, length;
	private bool left, right, ended = false, swipefinish = false, bound = true;
	private float x1, x2, x3, y1, y2, y3, tempx, tempy;
	void Start(){
		rb = GetComponent<Rigidbody> (); 
		right = false;
		left = false;

	}
	void FixedUpdate(){
		if (Input.touchCount > 0 && !swipefinish) {

			if (bound) {
				for (k = 0; k < Input.touchCount; k++) {

					if (i >= 5) {
						for (y = 0; y < 4; y++) {
							arrx [y] = 0;
							arry [y] = 0;
						}
						bound = false;
					}

					// finally k = touchcount   
					Touch touch = Input.GetTouch (k);
					if (touch.phase == TouchPhase.Moved) {
						if (tempx != Input.GetTouch (k).position.x && tempy != Input.GetTouch (k).position.y) {
							if (bound) {
								arrx [i] = Input.GetTouch (k).position.x;
								arry [i] = Input.GetTouch (k).position.y;;
								i++;
								x += 1;
							}
						}
						//Debug.Log (arr.Length);
						if (bound) {
							tempx = Input.GetTouch (k).position.x;
							tempy = Input.GetTouch (k).position.y;
						}
					} else if(touch.phase == TouchPhase.Ended) {
						ended = true;
						/*for (j = 0; j < 9; j++) {
							if (j == 1) {
								if (arr [0, j] > arr [0, j - 1]) {
									right = true;
								} else {
									left = true;
								}
							} else {
								if (arr [0, j] > arr [0, j+1] && right) {
									x2 = arr [0, j+1];
									y2 = arr [1, j+1];
								}
							}
						}*/
						//x3 = arr [0, j + 1];
						//y3 = arr [1, j+1];
						arrx.CopyTo(temp, 99);
						Array.Sort (temp);
						Debug.Log (temp [0]);
					}
				}
			}
			//k++;

			x1 = arrx [0];
			y1 = arry [0];

		}
		if (ended) {
			//Debug.Log (x1 + " " + y1);
			//Debug.Log (x2 + " " + y2);
			//Debug.Log (x3 + " " + y3);
		}
		//Bezier (x1, y1, x2, y2, x3, y3);

	}

	private void Bezier(float x1, float y1, float x2, float y2, float x3, float y3){
		if (ended) {
			//Debug.Log ("Inside Bezier");
			//Debug.Log (ended);
			ended = false;
			swipefinish = true;

		}

		double t;
		Vector3 pos = new Vector3 ();
		for (t = 0.0; t < 1.0; t += 0.0005)
		{
			double xt = (System.Math.Pow (1-t, 3)) * (double)(x1) + 3 * t * (System.Math.Pow (1-t, 2)) * (double)(x2) +
				3 * System.Math.Pow (t, 2) * (1-t) * (double)(x2) + System.Math.Pow (t, 3) * (double)(x3);

			double yt = (System.Math.Pow (1-t, 3)) * (double)(y1) + 3 * t * (System.Math.Pow (1-t, 2)) * (double)(y2) +
				3 * System.Math.Pow (t, 2) * (1-t) * (double)(y2) + System.Math.Pow (t, 3) * (double)(y3);

			pos.x = (float)xt;
			pos.y = (float)yt;
			pos.z = gameObject.transform.position.z;
			//gameObject.transform.position.x = xt;
			//gameObject.transform.position.y = yt;		//putpixel (xt, yt, WHITE);
			gameObject.transform.position = pos;
	
		}
	}
}

