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
    //-------------------------------------
    private float rotation = 0.0f;
    private float speedR = 250;
    private Quaternion qTo = Quaternion.identity;
    //-------------------------------------

	public Rigidbody rb;

	void Start () {
		leftK = Vector3.left;
		rightK = Vector3.right;
		view = "front";

		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
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
