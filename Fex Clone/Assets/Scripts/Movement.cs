using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed;
	// Use this for initialization
	// I will leave it blank for now because we won't need it unitl we actually have a start in game
	void Start () {
		
	}
	
	// Update is called once per frame
	//interwebs told me to use FixedUpdate for working with physics vs Update but we can prolly move it back
	/*
	void Update () {
		
	}
	*/
	void FixedUpdate(){
		if (Input.GetKey ("left")) {
			gameObject.transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		if (Input.GetKey ("right")) {
			gameObject.transform.Translate (Vector3.right * speed * Time.deltaTime);
		}
	}

}
