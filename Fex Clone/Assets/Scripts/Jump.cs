using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public float jumpForce;
	public bool grounded;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space") && grounded == true) {
			rigidBody.AddForce (Vector3.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	void onCollisionStay(Collision2D collision){
		if (collision.gameObject.tag == "Ground") {
			grounded = true;
		}
	}

	void onCollisionExit(Collision2D collision){
		if(collision.gameObject.tag == "Ground"){
			grounded = false;
		}
	}
}
