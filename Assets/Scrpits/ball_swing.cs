using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball_swing : MonoBehaviour {
	
	private Rigidbody rb;
	private ConstantForce cf;
	private float x0, y0, x1, y1, x, y;
	private bool left, right, began, ended, turned, printed, firstframe;
	private float[] arrx = new float[3];
	private float[] arry = new float[5];
	private float tempx, tempy, tempx2, tempy2;
	private int i, j, k = 0, h = 1;
	Vector3 temp = new Vector3();
	private Vector3 pos = new Vector3();
	private Vector3 world = new Vector3();
	private Vector3 something = new Vector3 ();
	private Vector3 help = new Vector3();
	private Vector3 please = new Vector3();
	private Vector3 deltaposition = new Vector3();
	public float factor1, factor2;
	private float u, height, Q;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		cf = GetComponent<ConstantForce> ();
		tempx = 0.0f;
		tempy = 0.0f;
		left = false;
		right = false;
		turned = false;
		ended = false;
		began = true;
		printed = false;
		firstframe = true;
		temp.x = 0;
		temp.y = 0;
	}

	void FixedUpdate(){
		if (Input.touchCount > 0) {
			Touch touch = new Touch ();
	
			if (touch.phase == TouchPhase.Began && began==true) {
				arrx [0] = Input.touches[0].position.x;
				arry [0] = Input.touches[0].position.y;
				//tempx = arrx [0];
				//tempy = arry [0];
				Debug.Log ("Began");
				//Debug.Log (arrx [0] + " " + arry [0]);
				began = false;
			}

			//tempx = arrx [0];
			//tempy = arry [0];

			if (Input.GetTouch(0).phase == TouchPhase.Moved) {

				//Debug.Log ("moved");
				if (Input.touches[0].position.x > arrx[0] && firstframe) {
					right = true;
					left = false;
					firstframe = false;
					Debug.Log ("right");
				}
				/*else if (Input.GetTouch(0).position.x < tempx) {
					left = true;
					right = false;
				}*/

				if (right) {
					tempx2 = Input.touches [0].position.x;
					tempy2 = Input.touches [0].position.y;
					//Debug.Log ((int)tempx2);
					if (tempx2 <= tempx ) {
						//Debug.Log ("Turning point!");
						arrx [1] = tempx;
						arry [1] = tempy;
						turned = true;
					} else if(tempx2 > tempx){
						tempx = tempx2;
						tempy = tempy2;
					}
					//Debug.Log (tempx2 + "   " + tempx);

				}
				//Debug.Log (tempx);
				if (left) {
					//Debug.Log ("left");
					while (k<Input.touchCount) {
						if (Input.GetTouch (k).position.x < tempx) {
							arrx [1] = Input.GetTouch (k).position.x;
							arry [1] = Input.GetTouch (k).position.y;
						}
						tempx = Input.GetTouch (k).position.x;
						k++;
					}
					k = 0;
				}
			}
			if (Input.touches[0].phase == TouchPhase.Ended) {
				arrx [2] = tempx2;
				arry [2] = tempy2;
			}

			if (Input.touches[0].phase == TouchPhase.Ended && !ended) {
				//Debug.Log (arrx [2] + " " + arry [2]);
				Debug.Log ("ended");
				ended = true;
			}

			if (ended) {
				if (!printed) {

					for (i = 0; i < 3; i++) {
						//Debug.Log (arrx [i] + "   " + arry [i]);
					}

					/*for (i = 0; i < 1; i++) {
						pos.x = arrx [i];pos.y = arry [i];pos.z = 0;
						world = Camera.main.ScreenToWorldPoint (pos);
						//Debug.Log (world);
						//pos.x *= 740;	//Screen to viewport conversion factor//
						//pos.z = arry [i];pos.y = 0;
						//world = Camera.main.ScreenToViewportPoint(pos);
						//Debug.Log (world);
						//Debug.Log (Screen.width + "   " + Screen.height);
					}*/

					printed = true;
					if (ended) {
						Bezier (arrx, arry);
					}
				}
			}
		}
			

	}


	void Bezier(float[] arrx, float[] arry){

		double t;

		Vector3 newpos = new Vector3 ();

		for (t = 0.0; t < 1.0; t += 0.005) {
			double xt = (System.Math.Pow (t, 2)) * (double)(arrx [2]) + 2 * t * (System.Math.Pow (1 - t, 1)) * (double)(arrx [1]) +
			            System.Math.Pow (1 - t, 2) * (double)(arrx [0]);
			
			double zt = (System.Math.Pow (t, 2)) * (double)(arry [2]) + 2 * t * (System.Math.Pow (1 - t, 1)) * (double)(arry [1]) +
			            System.Math.Pow (1 - t, 2) * (double)(arry [0]);
			
			newpos.x = (float)xt;
			newpos.z = (float)zt;
			newpos.y = 0.0f;
			//Debug.Log (pos.x+"   "+pos.z);
			//pos.z = gameObject.transform.position.z;
			//gameObject.transform.position.x = xt;
			//gameObject.transform.position.y = yt;		//putpixel (xt, yt, WHITE);
			//gameObject.transform.position = pos;
			deltaposition = newpos - temp;
			//Debug.Log (deltaposition.x);
			deltaposition.y = 0.0f;
			//rb.AddForce (deltaposition.x*factor1, 0.0f, 0.0f);


			//cf.force = new Vector3 (0.0f, 0.0f, 5.0f);

			//Debug.Log ("Force added");
			temp.x = newpos.x;
			temp.z = newpos.z;

		}
		Debug.Log ("Bezier ended");


	}



	void Trajectory(Vector3 u){
		
	}
}

/*double xt = (System.Math.Pow (1-t, 3)) * (double)(arrx[0]) + 3 * t * (System.Math.Pow (1-t, 2)) * (double)(arrx[1]) +
				3 * System.Math.Pow (t, 2) * (1-t) * (double)(arrx[1]) + System.Math.Pow (t, 3) * (double)(arrx[2]);

			double yt = (System.Math.Pow (1-t, 3)) * (double)(arry[0]) + 3 * t * (System.Math.Pow (1-t, 2)) * (double)(arry[1]) +
				3 * System.Math.Pow (t, 2) * (1-t) * (double)(arry[1]) + System.Math.Pow (t, 3) * (double)(arry[2]);
*/