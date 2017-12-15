using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFlip : MonoBehaviour {

	// Use this for initialization
	bool facingLeft = false;
	private Rigidbody player;

	void Start(){
		player = gameObject.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("left") && facingLeft == false){
			Vector3 theScaleL = transform.localScale;
			theScaleL.x *= -1;
			transform.localScale = theScaleL;
			facingLeft = true;
		}
		else if (Input.GetKeyDown("right") && facingLeft == true){
			Vector3 theScaleR = transform.localScale;
			theScaleR.x *= -1;
			transform.localScale = theScaleR;
			facingLeft = false;
		}
	}
}
