using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed;
    // Use this for initialization
    // I will leave it blank for now because we won't need it unitl we actually have a start in game
    public Vector3 leftK; //variable to holdm direction change for left arrow key
    public Vector3 rightK; //variable to hold direction change for right arrow key
    //-------------------------------------
    private float rotation = 0.0f;
    private float speedR = 250;
    private Quaternion qTo = Quaternion.identity;
    //-------------------------------------


	//--Animation

	private Animator anim;

	//--Animation

	//--Sounds
	private AudioSource woosh;


    private Rigidbody rg;

    void Start () {
        leftK = Vector3.left;
        rightK = Vector3.right;
        rg = GetComponent<Rigidbody>();
        rg.freezeRotation = true;
		anim = gameObject.GetComponent<Animator> ();

		AudioSource[] audios = GetComponents<AudioSource> ();
		woosh = audios [2];

	}

	void FixedUpdate(){
		if (Input.GetKey ("right")) {
			gameObject.transform.Translate (rightK * speed * Time.deltaTime);
			anim.SetFloat ("Speed", 0.2f);
		} else {
			anim.SetFloat ("Speed", 0.0f);
		}
		if (Input.GetKey ("left")) {
			gameObject.transform.Translate (leftK * speed * Time.deltaTime);
			anim.SetFloat ("Speed", 0.2f);
		}

        if (Input.GetKeyUp("d")) //shifting camera counter-clockwise
        {
			woosh.Play ();
            rotation -= 90;
            qTo = Quaternion.Euler(0, rotation, 0);
        }
        else if (Input.GetKeyUp("a")) //shifting camera clock-wise
        {
			woosh.Play ();
            rotation += 90;
            qTo = Quaternion.Euler(0, rotation, 0);
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, speedR * Time.deltaTime);
    }

}
