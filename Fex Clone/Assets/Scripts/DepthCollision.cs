using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthCollision : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        DepthCollider();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Ray ray = new Ray(player.transform.position, Vector3.down * 100);
	}

    void DepthCollider()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform; //get player game object
        GameObject[] groundObjects = GameObject.FindGameObjectsWithTag("Ground"); //gets all ground type objects

        for (int i = 0; i < groundObjects.Length; i++) //goes through the list of ground objects
        {
            Debug.Log("test");

            GameObject ground = groundObjects[i]; //setting ground object to current platform
            BoxCollider collider = ground.GetComponentInChildren<BoxCollider>(); //new collider object
            collider.center = Vector3.zero; //default position

            Vector3 colliderPos = collider.transform.TransformPoint(collider.center); //colliderPos centered on collider

            Vector3 playerPos = playerTransform.position; //new vector3 on player

            Vector3 newColliderPos;

            //testing just for the z coordinate right now, aka the default camera view
            newColliderPos = new Vector3(colliderPos.x, colliderPos.y, playerPos.z); //centers collider on z player position for forward and backward view

            newColliderPos = collider.transform.InverseTransformPoint(newColliderPos); //local space

            collider.center = newColliderPos; //set in world
        }
    }
}

