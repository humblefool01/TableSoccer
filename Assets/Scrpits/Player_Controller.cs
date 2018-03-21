using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {
    public float speed;
    public float eo,ew;
    private int k=0;
    private float speed2,count=1;
    private Rigidbody rb;
    private Renderer re;
    float moveHorizontal;
    float moveVertical;
    float x = 0;
    float y = 0;
    float z = 0;
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        re = GetComponent<Renderer>();

    }
	// Update is called once per frame
	void FixedUpdate () {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
        
           rb.AddForce(movement * speed);
           count++;
        
        
	}
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Gameobject")
        {
            Debug.Log("Collision Detected");
            re.material.color = Color.red;
            if ((eo == 1)&&(moveHorizontal==0)&&(moveVertical==0))
            {
                rb.velocity= Vector3.zero;
            }
            else if(eo == 0)
            {

            }
            
        }
        else if(col.gameObject.tag == "Walls")
        {
            rb.velocity = rb.velocity / 2;
        }
    }
    
   
}
