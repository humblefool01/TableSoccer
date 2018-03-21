using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Rotation : MonoBehaviour {
    private Transform pos;
	// Use this for initialization
	void Start () {
        pos = GetComponent<Transform>();
	}
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
    void OnCollisonEnter(Collision col)
    {
        if (col.gameObject.tag == "Sphere")
        {
            
        }
    }
}
