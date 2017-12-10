using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour {
	
	// Update is called once per frame

	void Update () {

		if (Input.GetKeyUp ("d")) {
			transform.RotateAround(Vector3.zero, Vector3.up, 90);
		}

		if (Input.GetKeyUp ("a")) {
			transform.RotateAround(Vector3.zero, Vector3.up, -90);

        }

		//transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
	}
}
