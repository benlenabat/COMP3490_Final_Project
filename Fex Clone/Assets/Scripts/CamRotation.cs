using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour {

    // Update is called once per frame
    private float rotation = 0.0f;
    private float speed = 0.5f;
    private Quaternion qTo = Quaternion.identity;

    void Update () { 

		if (Input.GetKeyUp ("d")) {
            transform.RotateAround(Vector3.zero, Vector3.up, -90);
            //rotation -= 90;
            //qTo = Quaternion.Euler(0, 0, rotation);
        }

		if (Input.GetKeyUp ("a")) {
			transform.RotateAround(Vector3.zero, Vector3.up, 90);
        }

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, speed * Time.deltaTime);

		//transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
	}
}
