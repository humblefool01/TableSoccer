using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Object : MonoBehaviour {
    public float e;
    private Renderer re;
	// Use this for initialization
	void Start () {
        re = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "GameController")
        {
            re.material.color = Color.blue;
        }
    }
   
}
