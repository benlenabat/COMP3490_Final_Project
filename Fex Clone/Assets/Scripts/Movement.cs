using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed;
    // Use this for initialization
    // I will leave it blank for now because we won't need it unitl we actually have a start in game
    public Vector3 leftK; //variable to holdm direction change for left arrow key
    public Vector3 rightK; //variable to hold direction change for right arrow key
    protected string view;
    //-------------------------------------
    private float rotation = 0.0f;
    private float speedR = 250;
    private Quaternion qTo = Quaternion.identity;
    //-------------------------------------

    void Start() {
        leftK = Vector3.left;
        rightK = Vector3.right;
        view = "front";
    }

    // Update is called once per frame
    //interwebs told me to use FixedUpdate for working with physics vs Update but we can prolly move it back
    /*
	void Update () {
		
	}
	*/

    void FixedUpdate(){
		if (Input.GetKey ("left")) {
			gameObject.transform.Translate (leftK * speed * Time.deltaTime);
		}
		if (Input.GetKey ("right")) {
			gameObject.transform.Translate (rightK * speed * Time.deltaTime);
		}
        if (Input.GetKeyUp("d")) //shifting camera counter-clockwise
        {
            rotation -= 90;
            qTo = Quaternion.Euler(0, rotation, 0);
            
            if (view == "front") //check view
            {
                view = "right"; //changes view
            }
            else if(view == "right")
            {
                view = "back";
            }
            else if(view == "back")
            {
                view = "left";
            }
            else if(view == "left")
            {
                view = "front";
            }
            
        }
        else if (Input.GetKeyUp("a")) //shifting camera clock-wise
        {
            rotation += 90;
            qTo = Quaternion.Euler(0, rotation, 0);
            
            if (view == "front")
            {
                view = "left";
            }
            else if (view == "left")
            {
                view = "back";
            }
            else if (view == "back")
            {
                view = "right";
            }
            else if (view == "right")
            {
                view = "front";
            }
                    }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, speedR * Time.deltaTime);
    }

}
