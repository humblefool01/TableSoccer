using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sphere : MonoBehaviour {
    private Rigidbody rb;
    private int i = 0;
    private Renderer re;
    public float speed;
    private float moveHorizontal;
    private float moveVertical;
    
	// Use this for initialization
	void Start () {
        re = GetComponent < Renderer>();
       
        rb = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void Update () {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
        rb.AddForce(movement * speed);
        transform.Translate(Input.acceleration.x, 0, Input.acceleration.z);

    }

    void OnTriggerEnter(Collider c)
    {
        i++;
        Debug.Log(i);
        Destroy(c.gameObject);
    }
}
