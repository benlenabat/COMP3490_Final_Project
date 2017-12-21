using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public float jumpForce;

	public bool isGrounded;
	private Rigidbody rb;
	private Animator anim;
	private AudioSource jumpSound;

	void Start(){
		rb = GetComponent<Rigidbody>();
		anim = gameObject.GetComponent<Animator> ();
		jumpSound = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter()
	{
		isGrounded = true;
		anim.SetBool ("Ground", isGrounded); // set animations
	}

	void Update(){

		if(Input.GetKeyDown(KeyCode.Space) && isGrounded){

			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			isGrounded = false;
			anim.SetBool ("Ground", false); 
			jumpSound.Play ();
		}
	}
}
