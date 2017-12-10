using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed;
    // Use this for initialization
    // I will leave it blank for now because we won't need it unitl we actually have a start in game
    public Vector3 leftK; //variable to holdm direction change for left arrow key
    public Vector3 rightK; //variable to hold direction change for right arrow key
    public string view;

	void Start () {
        leftK = Vector3.left;
        rightK = Vector3.right;
        view = "front";
	}

    public void frontSide() //when camera changes to the default front view
    {
        leftK = Vector3.left;
        rightK = Vector3.right;
    }

    public void backSide() //when camera changes to back view
    {
        leftK = Vector3.right;
        rightK = Vector3.left;
    }

    public void leftSide() //when camera changes to left view
    {
        leftK = Vector3.forward;
        rightK = Vector3.back;
    }

    public void rightSide() //when camera changes to right view
    {
        leftK = Vector3.back;
        rightK = Vector3.forward;
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
            if (view == "front") //check view
            {
                view = "right"; //changes view
                rightSide(); //sets controls
            }
            else if(view == "right")
            {
                view = "back";
                backSide();
            }
            else if(view == "back")
            {
                view = "left";
                leftSide();
            }
            else if(view == "left")
            {
                view = "front";
                frontSide();
            }
        }
        else if (Input.GetKeyUp("a")) //shifting camera clock-wise
        {
            if (view == "front")
            {
                view = "left";
                leftSide();
            }
            else if (view == "left")
            {
                view = "back";
                backSide();
            }
            else if (view == "back")
            {
                view = "right";
                rightSide();
            }
            else if (view == "right")
            {
                view = "front";
                frontSide();
            }
        }
    }

}
